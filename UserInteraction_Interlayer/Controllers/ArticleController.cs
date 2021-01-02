using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController (IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpGet]
        public List<Article> GetAll()
        {
            return _articleAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Article Get(long id)
        {
            return _articleAppService.Get(id);
        }

        [HttpPost]
        public Article Save([FromBody] Article article)
        {
            return _articleAppService.Save(article);
        }


    }
}