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

        //metoda kojom se briše feedback iz baze podataka sa odgovarajućim ID
        public void Delete(Feedback entity)
        {
            Feedback f = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            if(f != null)
            {
                myDbContext.Feedback.Remove(f);
                myDbContext.SaveChanges();
            }
        }

        // metoda kojom se unose izmene u bazu podataka za odgovarajući feedback
        public void Edit(Feedback entity)
        {
            Feedback f = myDbContext.Feedback.SingleOrDefault(feedback => feedback.Id == entity.Id);
            myDbContext.Feedback.Remove(f);
            myDbContext.Feedback.Add(entity);
            myDbContext.SaveChanges();
        }

        // metoda kojom se dobavlja feedback sa odgovarajucim ID iz baze podataka 
        public Feedback Get(long id)
        {
            Feedback result = myDbContext.Feedback.FirstOrDefault(feedback => feedback.Id == id);
            return result;
        }

        // metoda kojom se dobavlja lista feedback-ova iz baze podataka
        public IEnumerable<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            myDbContext.Feedback.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        // metoda kojom se cuva novi feedback u bazi podataka ako feedback sa takvim ID-om ne postoji
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
