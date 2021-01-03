using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IGetEager<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        public E GetEager(ID id);

        public IEnumerable<E> GetAllEager();
    }
}
