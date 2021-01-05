using SearchAndSchedule_Microservice.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface ICRUD<E, ID> where E : IIdentifiable<ID>
                             where ID : IComparable
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        E Save(E entity);
        void Delete(E entity);
        void Edit(E entity);
    }
}
