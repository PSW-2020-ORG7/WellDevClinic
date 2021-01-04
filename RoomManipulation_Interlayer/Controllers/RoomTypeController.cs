using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;

namespace RoomManipulation_Interlayer.Controllers
{
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeAppService _roomTypeAppService;

        public RoomTypeController(IRoomTypeAppService roomTypeAppService)
        {
            _roomTypeAppService = roomTypeAppService;
        }
        [HttpGet]
        public List<RoomType> GetAll()
        {
            return _roomTypeAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public RoomType Get(long id)
        {
            return _roomTypeAppService.Get(id);
        }

        [HttpPost]
        public RoomType Save(RoomType roomType)
        {
            return _roomTypeAppService.Save(roomType);
        }
        [HttpPut]
        [Route("edit")]
        public void Edit(RoomType roomType)
        {
            _roomTypeAppService.Edit(roomType);
        }

        [HttpPut]
        [Route("Delete")]
        public void Delete(RoomType roomType)
        {
            _roomTypeAppService.Delete(roomType);
        }
    }

}