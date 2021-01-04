using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;

namespace RoomManipulation_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentAppService _equipmentAppService;

        public EquipmentController(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Equipment Get(long id)
        {
            return _equipmentAppService.Get(id);
        }

        [HttpGet]
        public List<Equipment> GetAll()
        {
            return _equipmentAppService.GetAll().ToList();
        }

        [HttpPost]
        public Equipment Save(Equipment equipment)
        {
            return _equipmentAppService.Save(equipment);
        }

        [HttpGet]
        [Route("GetConsumableEquipment")]
        public List<Equipment> GetConsumableEquipment()
        {
            return _equipmentAppService.GetConsumableEquipment().ToList();
        }

        [HttpGet]
        [Route("GetInconsumableEquipment")]
        public List<Equipment> GetInconsumableEquipment()
        {
            return _equipmentAppService.GetInconsumableEquipment().ToList();
        }


    }
}