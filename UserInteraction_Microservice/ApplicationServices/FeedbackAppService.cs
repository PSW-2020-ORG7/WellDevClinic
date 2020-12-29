using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class FeedbackAppService : IFeedbackAppService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackAppService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void Delete(Feedback entity)
        {
            _feedbackRepository.Delete(entity);
        }

        public void Edit(Feedback entity)
        {
            _feedbackRepository.Edit(entity);
        }

        public Feedback Get(long id)
        {
            return _feedbackRepository.Get(id);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback Save(Feedback entity)
        {
            return _feedbackRepository.Save(entity);
        }
    }
}
