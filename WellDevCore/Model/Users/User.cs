using Repository;
using System;
using System.Drawing;

namespace Model.Users
{
   public abstract class User : Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }

        public long Id;

        public override long GetId()
        {
            throw new NotImplementedException();
        }

        public override void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}