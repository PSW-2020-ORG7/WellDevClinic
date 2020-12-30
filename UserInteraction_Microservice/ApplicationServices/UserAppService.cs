using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.DomainServices;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _domainService;

        public UserAppService(IUserDomainService domainService)
        {
            _domainService = domainService;
        }

        public User LogIn(string username, string password)
        {
            return _domainService.LogIn(username, password);
        }
    }
}
