using bolnica.Model;
using bolnica.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Feedback> result = new List<Feedback>();
            myDbContext.Feedback.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        public Feedback Save(Feedback entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
