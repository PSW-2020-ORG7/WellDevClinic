using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;

namespace SearchAndSchedule_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingExaminationController : ControllerBase
    {
        private readonly IExaminationAppService _examinationAppService;

        public UpcomingExaminationController(IExaminationAppService examinationAppService)
        {
            _examinationAppService = examinationAppService;
        }

        [HttpPost]
        public UpcomingExamination Save(UpcomingExamination upcomingExamination)
        {
            return _examinationAppService.Save(upcomingExamination);
        }

        [HttpGet]
        public List<UpcomingExamination> GetAll()
        {
            return _examinationAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public UpcomingExamination Get(long id)
        {
            return _examinationAppService.Get(id);
        }

        [HttpPut]
        [Route("Delete")]
        public void Delete(UpcomingExamination upcomingExamination)
        {
            _examinationAppService.Delete(upcomingExamination);
        }

        [HttpGet]
        [Route("GetPatientsForBlocking")]
        public List<Patient> GetPatientsForBlocking()
        {
           return _examinationAppService.GetPatientsForBlocking();
        }

        [HttpPut]
        [Route("Edit")]
        public void Edit(UpcomingExamination upcomingExamination)
        {
            _examinationAppService.Edit(upcomingExamination);
        }
        [HttpGet]
        [Route("GetExaminationRoom")]
        public Room GetExaminationRoom(UpcomingExamination examination)
        {
            return _examinationAppService.GetExaminationRoom(examination);
        }

        [HttpGet]
        [Route("GetUpcomingExaminationsByDoctor")]
        public List<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor)
        {
            return _examinationAppService.GetUpcomingExaminationsByDoctor(doctor);
        }

        [HttpPost]
        [Route("GetUpcomingExaminationsByPatient")]
        public List<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient)
        {
            return _examinationAppService.GetUpcomingExaminationsByPatient(patient);
        }

        //Pogledati detaljan opis u servisu, i ako je potrebna neki dto za ove parametre
        /*
                [HttpPost]
                [Route("GetUpcomingExaminationsByRoomAndPeriod")]
                public List<UpcomingExamination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
                {
                    return _examinationAppService.GetUpcomingExaminationsByRoomAndPeriod(room, period);
                }*/

        [HttpPut]
        [Route("Cancel/{id?}")]
        public void Cancel(long id)
        {
            _examinationAppService.Cancel(id);
        }

       
    }
}