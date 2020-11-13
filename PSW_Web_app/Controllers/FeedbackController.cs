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

        /// <summary>
        ///calls GetAll() method from class FeedbackController 
        ///so it can get all feedback from database
        /// </summary>
        /// <returns>status 200 OK response with a list of feedback</returns>
        [HttpGet]
        public IActionResult GetAllFeedback()
        {
            List<Feedback> result = (List<Feedback>)_feedbackController.GetAll();
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
            Feedback feedback = _feedbackController.Get(id);
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
            if(((List<Feedback>)_feedbackController.GetAll()).Count == 0)
            {
                feedback.Id = 0;
            }
            else
            {
                Feedback lastFeedback = ((List<Feedback>)_feedbackController.GetAll())[((List<Feedback>)_feedbackController.GetAll()).Count - 1];
                long id = lastFeedback.Id;
                feedback.Id = id + 1;
            }
            Feedback result = _feedbackController.Save(feedback);
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
            _feedbackController.Edit(feedback);
        }

    }
}
