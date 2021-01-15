using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}

