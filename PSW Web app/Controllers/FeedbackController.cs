using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private bolnica.Controller.IFeedbackController _feedbackController = new bolnica.Controller.FeedbackController();
        
        [HttpGet]
        public List<Feedback> GetAllFeedback()
        {
            return (List<Feedback>)_feedbackController.GetAll();
            
        }

        [HttpGet("{id?}")]
        public Feedback GetFeedback(long id)
        {
            return _feedbackController.GetFeedback(id);
        }

        [HttpPost]
        public void LeaveFeedback(Feedback feedback)
        {
            _feedbackController.LeaveFeedback(feedback);
        }

        [HttpPut]
        public void PublishFeedback(Feedback feedback)
        {
            _feedbackController.PublishFeedback(feedback);
        }

    }
}
