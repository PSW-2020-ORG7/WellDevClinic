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