using PSW_Wpf_app.Client;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PSW_Wpf_app.ViewModel
{
    public class EmergencyAppointmentViewModel : BindableBase
    {
        private BindingList<Equipment> equipments = new BindingList<Equipment>();
        private BindingList<ExaminationDTO> examinations = new BindingList<ExaminationDTO>();
        private BindingList<UpcomingExamination> examinationForDilay = new BindingList<UpcomingExamination>();
        private List<double> dileyTime = new List<double>();
        private List<ExaminationDTO> delayedTermExamination = new List<ExaminationDTO>();
        List<ExaminationDTO> allTerms = new List<ExaminationDTO>();
        public List<ExaminationDTO> DelayedTermExamination
        {
            get
            {
                return delayedTermExamination;
            }
            set
            {
                delayedTermExamination = value;
                OnPropertyChanged("DelayedTermExamination");
            }
        }
        public List<double> DileyTime
        {
            get
            {
                return dileyTime;
            }
            set
            {
                dileyTime = value;
                OnPropertyChanged("DileyTime");
            }
        }
        public BindingList<UpcomingExamination> ExaminationForDilay
        {
            get
            {
                return examinationForDilay;
            }
            set
            {
                examinationForDilay = value;
                OnPropertyChanged("ExaminationForDilay");
            }
        }

        public BindingList<Equipment> Equipments
        {
            get
            {
                return equipments;
            }
            set
            {
                equipments = value;
                OnPropertyChanged("Equipments");
            }
        }
        public BindingList<ExaminationDTO> Examinations
        {
            get
            {
                return examinations;
            }
            set
            {
                examinations = value;
                OnPropertyChanged("Examinations");
            }
        }
        public EmergencyAppointmentViewModel(int selectedType, Equipment equipment)
        {
            LoadTerms(selectedType, equipment);
        }

        public EmergencyAppointmentViewModel()
        {
            LoadEquipments();
        }

        private async void LoadEquipments()
        {
            Equipments = new BindingList<Equipment>(await WpfClient.GetAllEquipment());
        }

        private async void LoadTerms(int selectedType, Equipment equipment)
        {
            ExaminationDTO examination = await FindAllExaminations(selectedType, equipment);

            if (examination.Period != null)
            {
                Examinations.Add(examination);
            }
            else
            {
                MessageBox.Show("There are no free terms! We will run the analysis! ");
                List<UpcomingExamination> upcomingExaminations = await WpfClient.GetAllUpcomingExaminations();
                Dictionary<UpcomingExamination, ExaminationDTO> dilayTerm = new Dictionary<UpcomingExamination, ExaminationDTO>();

                List<UpcomingExamination> examinations = new List<UpcomingExamination>();
                examinations = await FindExaminationsByType(selectedType, upcomingExaminations);

                List<ExaminationDTO> terms = new List<ExaminationDTO>();
                terms = await FindAllTerms(dilayTerm, examinations, terms);

                Dictionary<UpcomingExamination, double> displayDifference = new Dictionary<UpcomingExamination, double>();
                DileyTimeSpan(dilayTerm, displayDifference);

                List<KeyValuePair<UpcomingExamination, double>> myList = SortTerms(displayDifference);
                AllExaminationsForDilay(myList);
                AllDileyTime(myList);
                TermForDeley(dilayTerm);
                return;
            }
        }

        private async Task<ExaminationDTO> FindAllExaminations(int selectedType, Equipment equipment)
        {
            List<Doctor> doctors = new List<Doctor>(await WpfClient.GetAllDoctors());
            Period period = new Period();
            period.StartDate = DateTime.Now;
            period.EndDate = period.StartDate.AddHours(1);

            doctors = GetDoctorsByType(doctors, selectedType);
            await FindDoctorTerms(doctors, period);

            List<ExaminationDTO> validTerms = findValidRooms(equipment, allTerms);
            ExaminationDTO examination = findEmergencyTerm(validTerms, period);
            return examination;
        }

        private async Task FindDoctorTerms(List<Doctor> doctors, Period period)
        {
            PriorityType priority = PriorityType.NoPriority;

            foreach (Doctor doctor in doctors)
            {
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
                List<ExaminationDTO> terms = await WpfClient.FindTerms(businessDayDTO);
                if (terms == null)
                    continue;

                allTerms.AddRange(terms);
            }
        }

        private void TermForDeley(Dictionary<UpcomingExamination, ExaminationDTO> dilayTerm)
        {
            foreach (UpcomingExamination e in ExaminationForDilay)
            {
                foreach (KeyValuePair<UpcomingExamination, ExaminationDTO> d in dilayTerm)
                {
                    if (d.Key.Equals(e))
                    {
                        if (d.Key.Period.StartDate.Equals(e.Period.StartDate))
                            DelayedTermExamination.Add(d.Value);
                    }
                }
            }
        }

        private void AllDileyTime(List<KeyValuePair<UpcomingExamination, double>> myList)
        {
            int n = 0;
            foreach (KeyValuePair<UpcomingExamination, double> d in myList)
            {
                if (n <= 2)
                    DileyTime.Add(d.Value);

                n++;
            }
        }

        private void AllExaminationsForDilay(List<KeyValuePair<UpcomingExamination, double>> myList)
        {
            int i = 0;
            foreach (KeyValuePair<UpcomingExamination, double> d in myList)
            {
                if (i <= 2)
                    ExaminationForDilay.Add(d.Key);
                i++;
            }
        }

        private static List<KeyValuePair<UpcomingExamination, double>> SortTerms(Dictionary<UpcomingExamination, double> displayDifference)
        {
            List<KeyValuePair<UpcomingExamination, double>> myList = displayDifference.ToList();
            myList.Sort(
                delegate (KeyValuePair<UpcomingExamination, double> pair1,
                KeyValuePair<UpcomingExamination, double> pair2)
                {
                    return pair1.Value.CompareTo(pair2.Value);
                });
            return myList;
        }

        private static void DileyTimeSpan(Dictionary<UpcomingExamination, ExaminationDTO> dilayTerm, Dictionary<UpcomingExamination, double> displayDifference)
        {
            foreach (KeyValuePair<UpcomingExamination, ExaminationDTO> d in dilayTerm)
            {
                TimeSpan difference = d.Value.Period.StartDate - d.Key.Period.StartDate;
                displayDifference[d.Key] = difference.TotalMinutes;
            }
        }

        private async Task<List<ExaminationDTO>> FindAllTerms(Dictionary<UpcomingExamination, ExaminationDTO> dilayTerm, List<UpcomingExamination> examinations, List<ExaminationDTO> terms)
        {
            foreach (UpcomingExamination ex in examinations)
            {
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(ex.Doctor, ex.Period, PriorityType.NoPriority);
                List<ExaminationDTO> termsFound = await WpfClient.FindTerms(businessDayDTO);
                terms = checkTime(termsFound);
                if (terms.Count == 0)
                {
                    termsFound = await WpfClient.FindTerms(businessDayDTO);
                    terms = checkTime(termsFound);
                }

                allTerms.AddRange(terms);
                dilayTerm[ex] = terms[0];
            }

            return terms;
        }

        private async Task<List<UpcomingExamination>> FindExaminationsByType(int selectedType, List<UpcomingExamination> upcomingExaminations)
        {
            List<UpcomingExamination> examinations = new List<UpcomingExamination>();
            List<UpcomingExamination> examinationsUpcoming = FindValidTimeTerms(upcomingExaminations);
            List<Doctor> allDoctors = await WpfClient.GetAllDoctors();
            List<Doctor> rightDoctorSpeciality = ExtractDoctors(selectedType, allDoctors);//vraca nam ili listu svih spec ili op

            foreach (UpcomingExamination ex in examinationsUpcoming)
            {
                foreach (Doctor d in rightDoctorSpeciality)
                {   
                    if (ex.Doctor.Id.Equals(d.Id))
                            examinations.Add(ex);
                }
            }

            return examinations;
        }

        private static List<Doctor> ExtractDoctors(int selectedType, List<Doctor> allDoctors)
        {
            List<Doctor> doctorsChoesenSpeciality = new List<Doctor>();
            foreach (Doctor d in allDoctors)
            {
                if (selectedType == 0)
                {
                    if (d.Speciality.Name.Equals("general practice"))
                        doctorsChoesenSpeciality.Add(d);
                }
                else
                {
                    if (!d.Speciality.Name.Equals("general practice"))
                        doctorsChoesenSpeciality.Add(d);
                }
            }
            return doctorsChoesenSpeciality;
        }

        private static List<UpcomingExamination> FindValidTimeTerms(List<UpcomingExamination> upcomingExaminations)
        {
            List<UpcomingExamination> examinationsCheck = new List<UpcomingExamination>();
            DateTime time = DateTime.Now.AddHours(1);

            foreach (UpcomingExamination exam in upcomingExaminations)
            {
                TimeSpan difference = exam.Period.EndDate.TimeOfDay - exam.Period.StartDate.TimeOfDay;
                if (difference.TotalHours < 1)
                    if (DateTime.Compare(exam.Period.StartDate.Date, DateTime.Now.Date) == 0 && (exam.Period.StartDate.TimeOfDay > DateTime.Now.TimeOfDay) && (exam.Period.StartDate.TimeOfDay < time.TimeOfDay))
                        examinationsCheck.Add(exam);
            }

            return examinationsCheck;
        }

        private List<ExaminationDTO> checkTime(List<ExaminationDTO> termsFound)
        {
            List<ExaminationDTO> terms = new List<ExaminationDTO>();
            foreach (ExaminationDTO t in termsFound)
            {
                if (t.Period.EndDate >= DateTime.Now)
                    terms.Add(t);
            }
            return terms;
        }

        private ExaminationDTO findEmergencyTerm(List<ExaminationDTO> validTerms, Period period)
        {
            ExaminationDTO exam = new ExaminationDTO();
            DateTime min = period.EndDate;
            foreach (ExaminationDTO ex in validTerms)
            {
                if (ex.Period.StartDate.TimeOfDay >= period.StartDate.TimeOfDay && ex.Period.EndDate.TimeOfDay <= period.EndDate.TimeOfDay)
                {
                    if (min.TimeOfDay >= ex.Period.StartDate.TimeOfDay)
                    {
                        min = ex.Period.StartDate;
                        exam = ex;
                    }
                }
            }
            return exam;
        }

        private List<Doctor> GetDoctorsByType(List<Doctor> doctors, int selectedType)
        {
            List<Doctor> generalPractice = new List<Doctor>();
            List<Doctor> specialists = new List<Doctor>();

            foreach (Doctor d in doctors)
            {
                if (d.Speciality.Name.Equals("general practice"))
                    generalPractice.Add(d);
                else
                    specialists.Add(d);
            }

            if (selectedType == 0)
                return generalPractice;
            else
                return specialists;

        }

        private List<ExaminationDTO> findValidRooms(Equipment equipment, List<ExaminationDTO> allTerms)
        {
            List<ExaminationDTO> examinations = new List<ExaminationDTO>();
            foreach (ExaminationDTO term in allTerms)
            {
                if (term.Room.EquipmentStatistic.Find(x => x.Equipment.Name == (equipment.Name)) != null)
                    examinations.Add(term);
            }

            if (examinations.Count == 0)
                MessageBox.Show("There is no selected equipment in any of rooms in hospital!");

            return examinations;
        }


    }
    
}
