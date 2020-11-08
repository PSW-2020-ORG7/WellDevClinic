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

        /// <summary>
        /// deletes specified feedback from database
        /// </summary>
        /// <param name="entity">specified feedback</param>
        public void Delete(Feedback entity)
        {
            Feedback result = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            if(result != null)
            {
                myDbContext.Feedback.Remove(result);
                myDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// updates specified feedback in database
        /// </summary>
        /// <param name="entity">specified feedback</param>
        public void Edit(Feedback entity)
        {
            Feedback result = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            myDbContext.Feedback.Remove(result);
            myDbContext.Feedback.Add(entity);
            myDbContext.SaveChanges();
        }

        /// <summary>
        /// gets feedback by id
        /// </summary>
        /// <param name="id">id of wanted feedback</param>
        /// <returns>object of type class Feedback with given id</returns>
        public Feedback Get(long id)
        {
            Feedback result = myDbContext.Feedback.FirstOrDefault(feedback => feedback.Id == id);
            return result;
        }

        /// <summary>
        /// get all feedback from database
        /// </summary>
        /// <returns>IEnumerable<Feedback> with all feedback from database</returns>
        public IEnumerable<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            myDbContext.Feedback.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        /// <summary>
        /// saves a new feedback to database
        /// </summary>
        /// <param name="entity">new feedback</param>
        /// <returns>Object of type feedback</returns>
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
