using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityController _specialityController;

        public SpecialityController(ISpecialityController specialityController)
        {
            _specialityController = specialityController;
        }


        [HttpGet]
        public List<Speciality> GetAllSpeciality()
        {
            List<Speciality> list = (List<Speciality>)_specialityController.GetAll();
            return list;
        }
    }
}
