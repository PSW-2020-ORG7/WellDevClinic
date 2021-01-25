using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
{
    public class Anamnesis : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Text { get; set; }

        public Anamnesis() { }
        public Anamnesis(long id, string text)
        {
            Id = id;
            Text = text;
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
