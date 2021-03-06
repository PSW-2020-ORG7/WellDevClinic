﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
{ 
    public class Sympthom : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Sympthom() { }
        public Sympthom(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
