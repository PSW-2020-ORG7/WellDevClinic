using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class ExaminationAppService : IExaminationAppService
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IBussinesDayAppService _businessDayAppService;

        public ExaminationAppService(IExaminationRepository examinationRepository, IBussinesDayAppService bussinesDayAppService)
        {
            _examinationRepository = examinationRepository;
            _businessDayAppService = bussinesDayAppService;
        }

        public void Delete(UpcomingExamination entity)
        {
            BusinessDay businessDay = _businessDayAppService.GetExactDay(entity.Doctor, entity.Period.StartDate.Date);
            _businessDayAppService.FreePeriod(businessDay, new List<DateTime> { entity.Period.StartDate });
            _examinationRepository.Delete(entity);
        }

        public void Edit(UpcomingExamination entity)
        {
            _examinationRepository.Edit(entity);
        }

        public UpcomingExamination Get(long id)
        {
            return _examinationRepository.Get(id);
        }

        public IEnumerable<UpcomingExamination> GetAll()
        {
            return _examinationRepository.GetAll();
        }


        public UpcomingExamination Save(UpcomingExamination entity)
        {
            return _examinationRepository.Save(entity);
        }

        public Room GetExaminationRoom(UpcomingExamination examination)
        {
            Room room = null;
            examination.Doctor.BussinesDays = _businessDayAppService.GetBusinessDaysByDoctor(examination.Doctor);
            foreach (BusinessDay businessDay in examination.Doctor.BussinesDays)
                if (businessDay.Shift.StartDate.Date == examination.Period.StartDate.Date)
                {
                    room = businessDay.Room;
                    break;
                }
            return room;
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor)
        {
            return _examinationRepository.GetUpcomingExaminationsByDoctor(doctor).ToList();
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient)
        {
            return _examinationRepository.GetUpcomingExaminationsByPatient(patient).ToList();
        }

        public List<UpcomingExamination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
        {
            //Ovo mora da se promeni zove se baza sto puta
            //Bilo bi dobro da se ne zove GetAll vec samo odredjeni za taj period (tipa metoda GetUpcExamByPeriod) kako bi smanjili broj poziva kod GetExaminationRoom
            //Ovo je filterska metoda, mozda cak ne bi trebala ni da bude ovde na beku           
            List<UpcomingExamination> examinations = new List<UpcomingExamination>();
            foreach (UpcomingExamination examination in GetAll())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0 && GetExaminationRoom(examination).Id == room.Id)
                    examinations.Add(examination);
            return examinations;
        }
    }
}
