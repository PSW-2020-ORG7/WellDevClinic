using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface ICRUD<E,ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        E Get(ID id);
        IEnumerable<E> GetAll();
        E Save(E entity);
        void Delete(E entity);
        void Edit(E entity);

        E GetEager(ID id);

        IEnumerable<E> GetAllEager();
    }
}
