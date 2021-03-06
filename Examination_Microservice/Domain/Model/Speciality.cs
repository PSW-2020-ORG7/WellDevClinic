﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Speciality : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }

        public Speciality() { }

        public Speciality(String Name)
        {
            this.Name = Name;
        }

        public Speciality(long id)
        {
            this.Id = id;
        }

        public Speciality(long id, String Name)
        {
            this.Id = id;
            this.Name = Name;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }

    }
}
