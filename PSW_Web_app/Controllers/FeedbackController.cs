using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;
using bolnica.Service;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService) {
            _feedbackService = feedbackService;
        }

        /// <summary>
        ///calls GetAll() method from class FeedbackController 
        ///so it can get all feedback from database
        /// </summary>
        /// <returns>status 200 OK response with a list of feedback</returns>
        [HttpGet]
        public IActionResult GetAllFeedback()
        {
            List<Feedback> result = (List<Feedback>)_feedbackService.GetAllFeedback();
            return Ok(result);
        }

        /// <summary>
        /// calls Get(long id) method from class FeedbackController so  
        /// it can get a feedback by given id from database
        /// </summary>
        /// <param name="id">id of wanted feedback</param>
        /// <returns>iActionResult object with a specified feedback</returns>
        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetFeedback(long id)
        {
            IActionResult actionResult;
            Feedback feedback = _feedbackService.GetFeedback(id);
            if (feedback == null)
            {
                actionResult = NotFound();
            }
            else
            {
                actionResult = Ok(feedback);
            }
            return actionResult;
        }

        /// <summary>
        /// calls Save(Feedback feedback) method from class FeedbackController so  
        ///it can save a new feedback to database
        /// </summary>
        /// <param name="feedback">new feedback of Object type Feedback</param>
        /// <returns>iActionResult object with a saved feedback</returns>
        [HttpPost]
        public IActionResult LeaveFeedback([FromBody] Feedback feedback)
        {
            IActionResult actionResult;
            Feedback result = _feedbackService.LeaveFeedback(feedback);
            if(result == null || feedback.Content.Length == 0)
            {
                actionResult = BadRequest();
            }
            else
            {
                actionResult = Ok(result);
            }
            return actionResult;
        }

       
       /// <summary>
       /// calls Edit(Feedback feedback) method from class FeedbackController so  
       ///it can update specified feedback in database
       /// </summary>
       /// <param name="feedback">sprecified feedback of Object type Feedback</param>
        [HttpPut]
        public void PublishFeedback(Feedback feedback)
        {
            _feedbackService.PublishFeedback(feedback);
        }

    }
}
