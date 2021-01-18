using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public enum UserType
    {
        Patient,
        Doctor,
        Secretary,
        Director
    }
    public class User
    {
        public virtual Person Person { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public virtual UserLogIn UserLogIn { get; set; }
        public virtual UserType UserType { get; set; }

    }
}
