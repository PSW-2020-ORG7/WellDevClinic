using bolnica.Model.Users;
using bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository = new FeedbackRepository();

        public FeedbackService()
        {
            
        }

        public List<Feedback> GetAllFeedback()
        {
            return (List<Feedback>)_feedbackRepository.GetAll();
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
    }
}
