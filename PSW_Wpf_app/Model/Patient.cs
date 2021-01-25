using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Patient:User
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false;
        public Boolean Blocked { get; set; } = false;
        public Boolean Validation { get; set; }
        public String VerificationToken { get; set; }
    }
}
