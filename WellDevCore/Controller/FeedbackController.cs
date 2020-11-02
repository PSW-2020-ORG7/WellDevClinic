using bolnica.Model.Users;
using bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Controller
{
    public class FeedbackController : IFeedbackController
    {
        private readonly IFeedbackService _feedbackService = new FeedbackService();

        /*public FeedbackController(IFeedbackService service)
        {
            _feedbackService = service;
        }*/

        public FeedbackController()
        {
            
        }

        public void Delete(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Feedback entity)
        {
            _feedbackService.PublishFeedback(entity);
        }

        public Feedback Get(long id)
        {
            return _feedbackService.GetFeedback(id);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackService.GetAllFeedback();

        }


        public Feedback Save(Feedback entity)
        {
            return _feedbackService.LeaveFeedback(entity);
        }
    }
}
