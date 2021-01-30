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
    public class MapEventController : ControllerBase
    {
        private readonly IDomainEventService _domainEventService;

        public MapEventController(IDomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<DomainEvent> GetAll()
        {
            return _domainEventService.GetAll("mapevent");
        }

        [HttpPost]
        [Route("save")]
        public MapEvent Save(MapEvent mapEvent)
        {
            var @event = new MapEvent(mapEvent.BuildingName, mapEvent.FloorLevel,mapEvent.Username);
            _domainEventService.Save(@event);
            return mapEvent;
        }

        [HttpGet]
        [Route("mostVisitedFloor/{username?}")]
        public MapEvent GetMostVisitedFloor(string username)
        {
            return _domainEventService.GetMostVisitedFloor(username);
        }
    }
}
