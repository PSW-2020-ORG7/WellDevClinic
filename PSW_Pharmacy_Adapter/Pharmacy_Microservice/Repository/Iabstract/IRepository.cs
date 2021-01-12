using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract
{
    public interface IRepository<E, ID>
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        bool Exists(ID id);
        bool Delete(ID id);
        E Save(E entity);
        E Update(E entity);
    }
}
