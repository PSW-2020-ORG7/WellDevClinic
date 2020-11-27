using bolnica.Model;
using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public IDoctorRepository _doctorRepository;
        public readonly MyDbContext myDbContext;
        public ArticleRepository(IDoctorRepository doctorRepository, MyDbContext context)
        {
            _doctorRepository = doctorRepository;
            myDbContext = context;
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Article entity)
        {
            throw new NotImplementedException();
        }

        public Article Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetEager()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllEager()
        {
            List<Article> articles = new List<Article>();
            foreach (Article article in GetEager().ToList())
            {
                articles.Add(GetEager(article.GetId()));
            }
            return articles;
        }

        public Article GetEager(long id)
        {
            Article article = Get(id);
            article.Doctor = _doctorRepository.GetEager(article.Doctor.GetId());

            return article;
        }

        public Article Save(Article entity)
        {
            throw new NotImplementedException();
        }
    }

}
