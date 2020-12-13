using bolnica.Repository;
using bolnica.Service;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Service
{
    public class ExaminationService : IExaminationService
    { 
        private readonly IExaminationUpcomingRepository _upcomingRepository;
        private readonly IExaminationPreviousRepository _previousRepository;
        public IDiagnosisService _diagnosisService { get; set; }
        public IPrescriptionService _prescriptionService { get; set; }
        public IReferralService _referralService { get; set; }
        public ISymptomService _symptomService { get; set; }
        public ITherapyService _therapyService { get; set; }

        //public IDoctorService _doctorService;
        //public IP _articleService;

        public ExaminationService(IExaminationUpcomingRepository upcomingRepository, IExaminationPreviousRepository previousRepository, IDiagnosisService diagnosisService, IPrescriptionService prescriptionService, IReferralService referralService, ISymptomService symptomService, ITherapyService therapyService)
        {
            _upcomingRepository = upcomingRepository;
            _previousRepository = previousRepository;
            _diagnosisService = diagnosisService;
            _prescriptionService = prescriptionService;
            _referralService = referralService;
            _symptomService = symptomService;
            _therapyService = therapyService;
            //_doctorService = doctorService;
            //_periodService = periodService;
        }

        public ExaminationService(IExaminationUpcomingRepository upcomingRepository, IExaminationPreviousRepository previousRepository)
        {
            _upcomingRepository = upcomingRepository;
            _previousRepository = previousRepository;
        }
        public ExaminationService( IExaminationPreviousRepository previousRepository)
        {
              _previousRepository = previousRepository;

        }

        public void Delete(Examination entity)
        {
            _upcomingRepository.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            _upcomingRepository.Edit(entity);
        }

        public void EditPrevious(Examination entity)
        {
            _previousRepository.Edit(entity);
        }

        public List<Examination> GetFinishedExaminationsByUser(long id)
        {
           
            List<Examination> examinations = _previousRepository.GetAllEager().ToList();
            List<Examination> findExamination = new List<Examination>();
            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id == id)
                {
                    findExamination.Add(examination);
                }
            }
            return findExamination;
            
        }

        public Examination Save(Examination entity)
        {
            return _upcomingRepository.Save(entity);
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            return _previousRepository.Save(examination);
        }

        public List<Examination> GetUpcomingExaminationsByUser(long id)
        {
            List<Examination> examinations = _upcomingRepository.GetAllEager().ToList();
            List<Examination> findExamination = new List<Examination>();
            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id == id)
                {
                    findExamination.Add(examination);
                }
            }
            return findExamination;
        }

        public List<Examination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination examination in GetAll())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0 && getExaminationRoom(examination).Id == room.Id)
                        examinations.Add(examination);

            return examinations;
        }

        public List<Examination> GetPreviousExaminationsByRoomAndPeriod(Room room, Period period)
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination examination in GetAllPrevious())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0 && getExaminationRoom(examination).Id == room.Id)
                    examinations.Add(examination);

            return examinations;
        }

        public Examination Get(long id)
        {
            return _upcomingRepository.Get(id);
        }

        public Examination GetPrevious(long id)
        {
            return _previousRepository.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _upcomingRepository.GetAllEager();
        }

        public List<Examination> GetAllPrevious()
        {
            return (List<Examination>)_previousRepository.GetAllEager();
        }

        private Boolean CheckDate(DateTime date, Examination examination)
        { 
            return examination.Period.StartDate.Date == date.Date;
        }

        private Boolean CheckDateAdvanced(String date1, String date2, Examination examination)
        {
            if (date1 == "" || date2 == "")
                return false;
            DateTime dateTime = DateTime.ParseExact(date1, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime dateTime2 = DateTime.ParseExact(date2, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return examination.Period.StartDate.Date >= dateTime && examination.Period.StartDate.Date <= dateTime2;
        }

        private Boolean CheckDoctor(String name, Examination examination)
        {
            if (name == "")
            {
                return false;
            }
            String doctorName = examination.Doctor.FullName.ToLower();
            return doctorName.Contains(name.ToLower());
        
        }
        /// <summary>
        /// Searches examinations of specified user by date, doctor, drug and specialist
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="doctorName">name of doctor</param>
        /// <param name="drugName">name of drug</param>
        /// <param name="speacialistName">name of specialist</param>
        /// <param name="user">specified user</param>
        /// <returns>list of examinations</returns>

        public List<Examination> SearchPreviousExamination(String date, String doctorName, String drugName, String speacialistName, long id) 
        { 
            List<Examination> result = new List<Examination>();
            List<Examination> examinations = GetFinishedExaminationsByUser(id).ToList();
            if (date != "")
            {
                DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                foreach (Examination examination in examinations)
                {
                    if (CheckDate(dateTime, examination) && CheckDoctor(doctorName, examination) && _prescriptionService.CheckDrug(drugName, examination.Prescription) && _referralService.CheckSpecialist(speacialistName, examination.Refferal))
                    {
                        result.Add(examination);
                    }
                }
            }
            else
            {
                foreach (Examination examination in examinations)
                {
                    if (CheckDoctor(doctorName, examination) && _prescriptionService.CheckDrug(drugName, examination.Prescription) && _referralService.CheckSpecialist(speacialistName, examination.Refferal))
                    {
                        result.Add(examination);
                    }
                }
            }
            return result;
        }

        public List<Examination> SearchPreviousExaminations(String date1, String date2, String doctorName, String drugName, String speacialistName, String text, Boolean Radio1, Boolean Radio2, Boolean Radio3)
        {
            List<Examination> result = new List<Examination>();
            List<Examination> examinations = GetAllPrevious().ToList();
            foreach (Examination examination in examinations)
            {
                var date_log = CheckDateAdvanced(date1, date2, examination);
                var doc_log = CheckDoctor(doctorName, examination);
                var spec_log = _referralService.CheckSpecialist(speacialistName, examination.Refferal);
                var text_log = _referralService.CheckText(text, examination.Refferal);
                var drug_log = _prescriptionService.CheckDrug(drugName, examination.Prescription);
                var provera = true;

                if (drugName != "")
                {
                    provera = drug_log;
                }
                else
                {
                    provera = spec_log;
                }

                if (Radio1 && Radio2 && Radio3)
                {
                    if (date_log && doc_log && provera && text_log)
                    {
                        result.Add(examination);
                    }
                }
                if (!Radio1 && Radio2 && Radio3)
                {
                    if ((date_log || doc_log) && provera && text_log)
                    {
                        result.Add(examination);
                    }
                }
                if (Radio1 && !Radio2 && Radio3)
                {
                    if ((date_log || provera) && doc_log  && text_log)
                    {
                        result.Add(examination);
                    }
                }
                if (Radio1 && Radio2 && !Radio3)
                {
                    if ((date_log || text_log) && doc_log && provera )
                    {
                        result.Add(examination);
                    }
                }
                if (!Radio1 && !Radio2 && Radio3)
                {
                    if ((date_log || doc_log || provera) && text_log)
                    {
                        result.Add(examination);
                    }
                }
                if (!Radio1 && Radio2 && !Radio3)
                {
                    if ((date_log || doc_log || text_log) && provera )
                    {
                        result.Add(examination);
                    }
                }
                if (Radio1 && !Radio2 && !Radio3)
                {
                    if ((date_log || provera || text_log) && doc_log)
                    {
                        result.Add(examination);
                    }
                }
                if (!Radio1 && !Radio2 && !Radio3)
                {
                    if (date_log || doc_log || provera || text_log)
                    {
                        result.Add(examination);
                    }
                }
            }
            return result;
        }


        public List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly)
        {
            List<Examination> examinations = GetAll().ToList();
            if (!upcomingOnly)
                examinations.AddRange(GetAllPrevious());

            for(int i = 0; i < examinations.Count; i++)
            {

                if (examinationDTO.Doctor != null && examinations[i].Doctor.FullName != examinationDTO.Doctor.FullName)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if (examinationDTO.Patient != null && examinations[i].Patient.FullName != examinationDTO.Patient.FullName)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if (examinationDTO.Period.StartDate > examinations[i].Period.StartDate || examinationDTO.Period.EndDate < examinations[i].Period.StartDate)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if(examinationDTO.Room != null && getExaminationRoom(examinations[i]).RoomCode != examinationDTO.Room.RoomCode)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }
            }
            return examinations;
        }

        public Room getExaminationRoom(Examination examination)
        {
            Room room = null;
            foreach (BusinessDay businessDay in examination.Doctor.BusinessDay)
                if (businessDay.Shift.StartDate.Date == examination.Period.StartDate.Date)
                {
                    room = businessDay.room;
                    break;
                }
            return room;
        }

        public List<DateTime> GetCancelationDatesByPatient(long id)
        {
            List<DateTime> result = new List<DateTime>();
            List<Examination> exams = (List<Examination>)_upcomingRepository.GetAllEager();
            exams.AddRange((List<Examination>)_previousRepository.GetAllEager());
            foreach(Examination exam in exams)
            {
                if (exam.Patient.Id == id && exam.Canceled && (DateTime.Today.Date - exam.CanceledDate.Date).TotalDays <= 30)
                    result.Add(exam.CanceledDate);
            }
            return result;
        }


        public Examination NewExamination(long DoctorId, String Period)
        {
            String[] dateTimes = Period.Split("S");
            DateTime start = DateTime.Parse(dateTimes[0]);
            DateTime end = DateTime.Parse(dateTimes[1]);
            Examination examination = _upcomingRepository.Save(DoctorId, new Period(start,end));
            return examination;
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            return _upcomingRepository.GetUpcomingExaminationsByUser(user);
        }

        public List<Examination> GetFinishedExaminationsByUser(User user)
        {
            return _previousRepository.GetFinishedExaminationsByUser(user);
        }
    }
}