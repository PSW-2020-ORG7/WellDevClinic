using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}

