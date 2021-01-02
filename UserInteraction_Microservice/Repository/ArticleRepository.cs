using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _myDbContext;

        public ArticleRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Article entity)
        {
            _myDbContext.Articles.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Article entity)
        {
            _myDbContext.Articles.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Article Get(long id)
        {
            return _myDbContext.Articles.Select(a =>
            new Article()
            {
                Id = a.Id,
                DatePublished = a.DatePublished,
                Doctor = new Doctor(a.Doctor.Id, a.Doctor.Speciality, a.Doctor.DoctorGrade, a.Doctor.Person, null, null), 
                Topic = a.Topic,
                Text = a.Text
            }).Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<Article> GetAll()
        {
            return _myDbContext.Articles.Select(a =>
             new Article()
             {
                 Id = a.Id,
                 DatePublished = a.DatePublished,
                 Doctor = new Doctor(a.Doctor.Id, a.Doctor.Speciality, a.Doctor.DoctorGrade, a.Doctor.Person, null, null),
                 Topic = a.Topic,
                 Text = a.Text
             }).ToList();
        }

        public Article Save(Article entity)
        {
            var Article = _myDbContext.Articles.Add(entity);
            _myDbContext.SaveChanges();
            return Article.Entity;
        }
    }
}
