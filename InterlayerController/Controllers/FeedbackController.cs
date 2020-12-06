using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model.Users;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        /// <summary>
        ///calls GetAll() method from class FeedbackService
        ///so it can get all feedback from database
        /// </summary>
        /// <returns>status 200 OK response with a list of feedback</returns>
        [HttpGet]
        public List<Feedback> GetAllFeedback()
        {
            return _feedbackService.GetAllFeedback();
        }

        /// <summary>
        /// calls Get(long id) method from class FeedbackService so  
        /// it can get a feedback by given id from database
        /// </summary>
        /// <param name="id">id of wanted feedback</param>
        /// <returns>iActionResult object with a specified feedback</returns>
        [HttpGet]
        [Route("{id?}")]
        public Feedback GetFeedback(long id)
        {
            return _feedbackService.GetFeedback(id);
        }

        /// <summary>
        /// calls Save(Feedback feedback) method from class FeedbackService so  
        ///it can save a new feedback to database
        /// </summary>
        /// <param name="feedback">new feedback of Object type Feedback</param>
        /// <returns>iActionResult object with a saved feedback</returns>
        [HttpPost]
        public Feedback LeaveFeedback([FromBody] Feedback feedback)
        {
            return _feedbackService.LeaveFeedback(feedback);
        }


        /// <summary>
        /// calls Edit(Feedback feedback) method from class FeedbackService so  
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
       

