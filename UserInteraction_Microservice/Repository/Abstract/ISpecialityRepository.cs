using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    interface ISpecialityRepository : ICRUD<Speciality, long>
    {
    }
}
