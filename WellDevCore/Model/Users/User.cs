using Repository;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using WellDevCore.Model.Users;

namespace Model.Users
{
    public abstract class User : Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }
        [NotMapped]
        public UserType Type { get; set; }
        public long Id {get; set;}

        public User() { }

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