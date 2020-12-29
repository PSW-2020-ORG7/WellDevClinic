using PSW_Wpf_app.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace PSW_Wpf_app.ViewModel
{
    public class EmergencyAppointmentViewModel : BindableBase
    {
        private BindingList<Equipment> equipments = new BindingList<Equipment>();
        private BindingList<ExaminationDTO> examinations = new BindingList<ExaminationDTO>();

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
            List<Doctor> doctors = new List<Doctor>(await WpfClient.GetAllDoctors());
            
            doctors = GetDoctorsByType(doctors, selectedType);

            PriorityType priority = PriorityType.NoPriority;
            Period period = new Period();
            period.StartDate = DateTime.Now;
            period.EndDate = period.StartDate.AddHours(1);
            List<ExaminationDTO> allTerms = new List<ExaminationDTO>();
            foreach (Doctor doctor in doctors)
            {
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period, priority);
                businessDayDTO.PatientScheduling = true;
                List<ExaminationDTO> terms = await WpfClient.FindTerms(businessDayDTO);
                if (terms == null) {
                    continue;
                }
                allTerms.AddRange(terms);
            }

            List<ExaminationDTO> validTerms = findValidRooms(equipment, allTerms);
            ExaminationDTO examination = findEmergencyTerm(validTerms, period);

            if (examination == null)
                MessageBox.Show("There are no free terms!");

            Examinations.Add(examination);
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
                if (d.Specialty.Name.Equals("general practice"))
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
                if (term.Room.Equipment_inventory.Find(x => x.Equipment.Name == (equipment.Name)) != null)
                    examinations.Add(term);
            }

            if (examinations.Count == 0)
                MessageBox.Show("There is no selected equipment in any of rooms in hospital!");

            return examinations;
        }

       
    }
    
}
