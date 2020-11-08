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

        /* metoda koja se pogađa HTTP GET zahtevom i poziva odgovarajuću metodu
        * iz _feedbackController-a kako bi se dobavili svi feedback-ovi 
        */
        [HttpGet]
        public IActionResult GetAllFeedback()
        {
            List<Feedback> result = (List<Feedback>)_feedbackController.GetAll();
            return Ok(result);
        }

        /* metoda koja se pogađa HTTP GET zahtevom i poziva odgovarajuću metodu
         * iz _feedbackController-a kako bi se dobavio feedback sa odgovarajućim ID
         */
        //[HttpGet("{id?}")]
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

        /* metoda koja se pogađa HTTP POST zahtevom i poziva odgovarajuću
         * metodu iz _feedbackController-a kako bi se poslati feedback iz forme
         * uskladištio u bazi
         */
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
            Feedback f = _feedbackController.Save(feedback);
            if(f == null || feedback.Content.Length == 0)
            {
                actionResult = BadRequest();
            }
            else
            {
                actionResult = Ok(f);
            }
            return actionResult;
        }

        /* metoda koja se pogađa HTTP PUT zahtevom i poziva odgovarajuću
         * metodu iz _feedbackController-a kako bi se označeni feedback objavio 
        */
        [HttpPut]
        public void PublishFeedback(Feedback feedback)
        {
            _feedbackController.Edit(feedback);
        }

    }
}
