using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IAddressAppService : ICRUD<Address, long>, IGetEager<Address, long>
    {
    }
}
