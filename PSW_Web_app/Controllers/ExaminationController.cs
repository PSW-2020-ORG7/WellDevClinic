using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Web_app.dtos;
using PSW_Web_app.Adapters;
using bolnica.Controller;

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private bolnica.Controller.IExaminationController _examinationController= new bolnica.Controller.ExaminationController();

        [HttpGet]
        public List<ExaminationDto> GetFinishedxaminationsByUser(User user)
        {
            _examinationController.GetFinishedxaminationsByUser(user);
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetFinishedxaminationsByUser(user);
            foreach (Examination examination in result) {
                ReferralDto referralDto = ReferralAdapter.ReferralToReferralDto(examination.Refferal);
                PrescriptionDto prescriptionDto = PrescriptionAdapter.PrescriptionToPrescriptionDto(examination.Prescription);
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination, referralDto, prescriptionDto)); 
            }
            return resultDto;
        }

    }
}
