﻿using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IArticleRepository : ICRUD<Article,long>
    {
    }
}
