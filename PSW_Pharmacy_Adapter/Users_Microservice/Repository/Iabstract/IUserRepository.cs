using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Users_Microservice.Repository.Iabstract
{
    public interface IUserRepository : IRepository<User, string>
    {
        User Get(User user);
    }
}
