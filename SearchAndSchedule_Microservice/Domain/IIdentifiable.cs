using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}
