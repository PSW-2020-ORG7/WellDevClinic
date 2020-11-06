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
        public IActionResult GetAllFeedback()
        {
            List<Feedback> result = (List<Feedback>)_feedbackController.GetAll();
            return Ok(result);
        }

        [HttpGet("{id?}")]
        public IActionResult GetFeedback(long id)
        {
            Feedback feedback = _feedbackController.Get(id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(feedback);
            }
        }

        [HttpPost]
        public IActionResult LeaveFeedback([FromBody] Feedback feedback)
        {
            Feedback f = _feedbackController.Save(feedback);
            if(f == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(f);
            }

        }

        [HttpPut]
        public void PublishFeedback(Feedback feedback)
        {
            _feedbackController.Edit(feedback);
        }

    }
}
