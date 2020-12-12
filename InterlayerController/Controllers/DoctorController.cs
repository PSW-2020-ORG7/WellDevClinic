using bolnica.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorController _doctorController;

        public DoctorController(IDoctorController doctorController)
        {
            _doctorController = doctorController;
        }

        /// <summary>
        ///calls GetAll() method from class EquipmentController 
        ///so it can get all equipment from database
        /// </summary>
        /// <returns>status 200 OK response with a list of equipment</returns>
        [HttpGet]

        public IEnumerable<Doctor> GetAllDoctors()
        {
            List<Doctor> result = (List<Doctor>)_doctorController.GetAll();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].BusinessDay != null)
                    for (int j = 0; j < result[i].BusinessDay.Count; j++)
                    {
                        result[i].BusinessDay[j].doctor = null;
                    }
            }
            return result;
        }
    }
}
