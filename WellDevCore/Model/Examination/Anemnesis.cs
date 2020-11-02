
using System;

namespace Model.PatientSecretary
{
   public class Anemnesis
   {
      public String Text { get; set; }
        public long Id { get; set; }
        public Anemnesis(String text)
        {
            this.Text = text;
        }

        public Anemnesis()
        {
            
        }

    }
}