using bolnica.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private IEquipmentController _equipmentController;

        public EquipmentController(IEquipmentController equipmentController)
        {
            _equipmentController = equipmentController;
        }
        /// <summary>
        ///calls GetAll() method from class EquipmentController 
        ///so it can get all equipment from database
        /// </summary>
        /// <returns>status 200 OK response with a list of equipment</returns>
        [HttpGet]

        public IEnumerable<Equipment> GetAllEquipment()
        {
            List<Equipment> result = (List<Equipment>)_equipmentController.GetAll();

            return result;
        }
    }
}
