using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackAppService _feedbackAppService;

        public FeedbackController(IFeedbackAppService feedbackAppService)
        {
            _feedbackAppService = feedbackAppService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Feedback Get(long id)
        {
            return _feedbackAppService.Get(id);
        }

        [HttpGet]
        public List<Feedback> GetAll()
        {
            return _feedbackAppService.GetAll().ToList();
        }

        [HttpPost]
        public Feedback LeaveFeedback([FromBody] Feedback feedback)
        {
            return _feedbackAppService.Save(feedback);
        }

        [HttpPut]
        public void PublishFeedback([FromBody] Feedback feedback)
        {
            _feedbackAppService.Edit(feedback);
        }
    }
}