using DrugManipulation_Microservice.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.ApplicationServices.Abstract
{
    public interface IGetEager<E, ID>
     where E : IIdentifiable<ID>
     where ID : IComparable
    {
        public E GetEager(ID id);

        public IEnumerable<E> GetAllEager();
    }
}
