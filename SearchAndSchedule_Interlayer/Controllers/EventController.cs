using EventSourcing;
using EventSourcing.Events;
using EventSourcing.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAndSchedule_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IDomainEventService _domainEventService;

        public EventController(IDomainEventService domainEventService)
        {
            _domainEventService = domainEventService;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<DomainEvent> GetAll()
        {
           return _domainEventService.GetAll("newexaminationtimespent");
        }

        [HttpPost]
        [Route("save")]
        public NewExaminationTimeSpent Save(NewExaminationTimeSpent nets)
        {
            return (NewExaminationTimeSpent)_domainEventService.Save(nets);
        }

        [HttpGet]
        [Route("max")]
        public long GetMax()
        {
            return _domainEventService.GetMax("newexaminationtimespent");
        }

        [HttpGet]
        [Route("stepTime")]
        public AverageTimeDTO GetStepTime()
        {
            return _domainEventService.GetStepTime("newexaminationtimespent");
        }

        [HttpGet]
        [Route("success")]
        public AverageTimeDTO GetSuccessPercentage()
        {
            return _domainEventService.GetStepTime("newexaminationtimespent");
        }

    }
}
