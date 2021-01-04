using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Delete(Article entity)
        {
            _articleRepository.Delete(entity);
        }

        public void Edit(Article entity)
        {
            _articleRepository.Edit(entity);
        }

        public Article Get(long id)
        {
            return _articleRepository.Get(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _articleRepository.GetAll().ToList();
        }

        public Article Save(Article entity)
        {
            return _articleRepository.Save(entity);
        }
    }
}
