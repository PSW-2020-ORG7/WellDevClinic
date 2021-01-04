using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityAppService _specialityAppService;

        public SpecialityController(ISpecialityAppService specialityAppService)
        {
            _specialityAppService = specialityAppService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Speciality Get(long id)
        {
            return _specialityAppService.Get(id);
        }

        [HttpGet]
        public List<Speciality> GetAll()
        {
            return _specialityAppService.GetAll().ToList();
        }

    }
}