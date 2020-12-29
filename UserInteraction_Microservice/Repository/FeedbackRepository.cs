using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    class FeedbackRepository : IFeedbackRepository
    {
        private readonly MyDbContext _myDbContext;

        public FeedbackRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Feedback entity)
        {
            _myDbContext.Feedback.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Feedback entity)
        {
            _myDbContext.Feedback.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Feedback Get(long id)
        {
            return _myDbContext.Feedback.Select(f =>
            new Feedback()
            {
                Id = f.Id,
                Patient = new Patient(f.Patient.Id, f.Patient.Guest, f.Patient.Blocked, f.Patient.Person, null, null),
                Content= f.Content,
                IsPrivate = f.IsPrivate,
                Publish = f.Publish,
                IsAnonymous = f.IsAnonymous
            }

            ).Where(f => f.Id == id).First();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _myDbContext.Feedback.Select(f =>
             new Feedback()
             {
                 Id = f.Id,
                 Patient = new Patient(f.Patient.Id, f.Patient.Guest, f.Patient.Blocked, f.Patient.Person, null, null),
                 Content = f.Content,
                 IsPrivate = f.IsPrivate,
                 Publish = f.Publish,
                 IsAnonymous = f.IsAnonymous
             }

             ).ToList();
        }

        public IEnumerable<Feedback> GetAllEager()
        {
            return _myDbContext.Feedback.ToList();
        }

        public Feedback GetEager(long id)
        {
            return _myDbContext.Feedback.FirstOrDefault(f => f.Id == id);
        }

        public Feedback Save(Feedback entity)
        {
            _myDbContext.Feedback.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
