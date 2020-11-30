using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Repository.Iabstract
{
    public interface IRepository<E, ID>
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        bool Exists(ID id);
        bool Delete(ID id);
        E Save(E Entity);
    }
}
