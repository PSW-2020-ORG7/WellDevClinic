using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.DTO;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public bool AddPharmacy([FromBody]ApiDTO apiDTO)  //TODO: Proveriti jel valja parametar
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id?}")]
        public ApiDTO GetPharmacy(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<ApiDTO> GetAllPharmacies()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("/delete/{id?}")]
        public bool DeletePharmacy(string id)
        {
            throw new NotImplementedException();
        }


    }
}
