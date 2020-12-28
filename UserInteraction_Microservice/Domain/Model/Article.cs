using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Article : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual Doctor Doctor { get; set; }
        public String Topic { get; set; }
        public String Text { get; set; }

        public Article()
        {
        }

        public Article(long id, DateTime datePublished, Doctor doctor, string topic, string text)
        {
            Id = id;
            DatePublished = datePublished;
            Doctor = doctor;
            Topic = topic;
            Text = text;
        }

        public Article(DateTime datePublished, Doctor doctor, string topic, string text)
        {
            DatePublished = datePublished;
            Doctor = doctor;
            Topic = topic;
            Text = text;
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
