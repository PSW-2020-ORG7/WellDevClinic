using bolnica.Model;
using bolnica.Model.Users;
using System.Collections.Generic;
using System.Linq;


namespace bolnica.Repository
{
    class FeedbackRepository:IFeedbackRepository
    {
        private readonly MyDbContext myDbContext; 

        public FeedbackRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public void Delete(Feedback entity)
        {
            Feedback f = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            if(f != null)
            {
                myDbContext.Feedback.Remove(f);
                myDbContext.SaveChanges();
            }

        }

        public void Edit(Feedback entity)
        {
            Feedback f = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            myDbContext.Feedback.Remove(f);
            myDbContext.Feedback.Add(entity);
            myDbContext.SaveChanges();
        }

        public Feedback Get(long id)
        {
            Feedback result = myDbContext.Feedback.FirstOrDefault(feedback => feedback.Id == id);
            return result;
        }

        public IEnumerable<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            myDbContext.Feedback.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        public Feedback Save(Feedback entity)
        {
            Feedback result = myDbContext.Feedback.FirstOrDefault(feedback => feedback.Id == entity.Id);
            if(result == null)
            {
                myDbContext.Feedback.Add(entity);
                myDbContext.SaveChanges();
                return entity;
            }

            return null;
        }

       
    }
}
