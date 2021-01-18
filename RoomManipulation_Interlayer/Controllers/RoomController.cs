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
    public class RoomController : ControllerBase
    {
        private readonly IRoomAppService _roomAppService;

        public RoomController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        [HttpGet]
        public List<Room> GetAll()
        {
            return _roomAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Room Get(long id)
        {
            return _roomAppService.Get(id);
        }

        [HttpPost]
        public Room Save(Room room)
        {
            return _roomAppService.Save(room);
        }

        [HttpPut]
        [Route("DeleteEquipmentFromRooms")]
        public void DeleteEquipmentFromRooms(Equipment equipment)
        {
            _roomAppService.DeleteEquipmentFromRooms(equipment);
        }

        [HttpPut]
        [Route("DeleteRoomsByRoomType")]
        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            _roomAppService.DeleteRoomsByRoomType(roomType);
        }

        [HttpPost]
        [Route("GetRoomsCointainingEquipment")]
        public List<Room> GetRoomsCointainingEquipment(Equipment equipment)
        {
            return _roomAppService.GetRoomsCointainingEquipment(equipment).ToList();
        }

        [HttpGet]
        [Route("GetRoomsForHospitalization")]
        public List<Room> GetRoomsForHospitalization()
        {
            return _roomAppService.GetRoomsForHospitalization();
        }
    }
}