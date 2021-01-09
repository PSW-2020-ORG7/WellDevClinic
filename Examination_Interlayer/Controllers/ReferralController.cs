using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Examination_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralController : ControllerBase
    {
        private readonly IReferralAppService _referralAppService;

        public ReferralController(IReferralAppService referralAppService)
        {
            _referralAppService = referralAppService;
        }

        [HttpGet]
        public List<Referral> GetAll()
        {
            return _referralAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Referral Get(long id)
        {
            return _referralAppService.Get(id);
        }

        [HttpPost]
        public Referral Save(Referral referral)
        {
            return _referralAppService.Save(referral);
        }
    }
}