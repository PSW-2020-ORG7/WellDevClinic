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
    public class RenovationController : ControllerBase
    {
        private readonly IRenovationAppService _renovationAppService;

        public RenovationController(IRenovationAppService renovationAppService)
        {
            _renovationAppService = renovationAppService;
        }

        [HttpGet]
        public List<Renovation> GetAll()
        {
            return _renovationAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Renovation Get(long id)
        {
            return _renovationAppService.Get(id);
        }

        [HttpPost]
        public Renovation Save(Renovation renovation)
        {
            return _renovationAppService.Save(renovation);
        }

        [HttpPut]
        [Route("DeleteRenovationByRoom")]
        public void DeleteRenovationByRoom(Room room)
        {
            _renovationAppService.DeleteRenovationByRoom(room);
        }

/*        
 *    TODO: Napraviti DTO objekat u ovom interleyeru koji ce da sadrzi room i period kako bi se slao kao parametar 
 *        [HttpPost]
        [Route("GetRenovationsByRoomAndPeriod")]
        public void GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            _renovationAppService.GetRenovationsByRoomAndPeriod(room, period);
        }*/
    }
}