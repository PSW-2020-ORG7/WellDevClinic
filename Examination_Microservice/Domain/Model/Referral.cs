using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Referral : IIdentifiable<long>
    {
        public long Id { get; set; }

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
