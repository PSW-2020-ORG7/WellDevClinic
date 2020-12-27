using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Feedback : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Patient Patient { get; set; }
        public String Content { get; set; }
        public Boolean IsPrivate { get; set; }
        public Boolean Publish { get; set; }
        public Boolean IsAnonymous { get; set; }

        public Feedback(long id, Patient patient, string content, bool isPrivate, bool publish, bool isAnonymous)
        {
            Id = id;
            Patient = patient;
            Content = content;
            IsPrivate = isPrivate;
            Publish = publish;
            IsAnonymous = isAnonymous;
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
