using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IArticleAppService : ICRUD<Article,long>
    {
    }
}
