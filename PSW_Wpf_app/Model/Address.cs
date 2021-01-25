using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Address
    {
        public long Id { get; set; }
        public String Street { get; set; }
        public int Number { get; set; }
        public String FullAddress { get; set; }
        public virtual Town Town { get; set; }
        public virtual State State { get; set; }

        public Address() { }
    }
}
