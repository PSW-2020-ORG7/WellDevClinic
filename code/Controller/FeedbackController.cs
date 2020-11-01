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
            throw new NotImplementedException();
        }

        public Feedback Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackService.GetAllFeedback();

        }

        public Feedback GetFeedback(long id)
        {
            throw new NotImplementedException();
        }

        public void LeaveFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public void PublishFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Feedback Save(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
