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
    public class RoomController : ControllerBase
    {
        private IRoomController _roomController;

        public RoomController(IRoomController roomController)
        {
            _roomController = roomController;
        }

        /// <summary>
        ///calls GetAll() method from class EquipmentController 
        ///so it can get all equipment from database
        /// </summary>
        /// <returns>status 200 OK response with a list of equipment</returns>
        [HttpGet]
        [Route("{id?}")]
        public Room GetRoomById(long id)
        {
            Room result = (Room)_roomController.Get(id);

            return result;
        }
    }
}
