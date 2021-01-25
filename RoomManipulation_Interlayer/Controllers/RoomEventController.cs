using EventSourcing;
using EventSourcing.Events;
using EventSourcing.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManipulation_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomEventController : ControllerBase
    {
        private readonly IDomainEventService _domainEventService;

        public RoomEventController(IDomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<DomainEvent> GetAll()
        {
            return _domainEventService.GetAll("roomevent");
        }

        [HttpPost]
        [Route("save")]
        public RoomEvent Save(RoomEvent roomEvent)
        {
            return (RoomEvent)_domainEventService.Save(roomEvent);
        }

        [HttpGet]
        [Route("mostVisitedRoom")]
        public long GetMostVisitedRoom()
        {
            return _domainEventService.GetMostVisitedRoom();
        }
    }
}
