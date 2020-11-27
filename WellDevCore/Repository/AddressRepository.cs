using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model;
using bolnica.Repository.CSV;
using Model.Users;

namespace bolnica.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MyDbContext myDbContext;

        public AddressRepository(MyDbContext context)
        {
            myDbContext = context;
        }


        public Address Get(long id)
            => myDbContext.Address.FirstOrDefault(address => address.Id == id);

        public IEnumerable<Address> GetEager()
        {
            List<Address> result = new List<Address>();
            myDbContext.Address.ToList().ForEach(address => result.Add(address));
            return result;
        }

        public IEnumerable<Address> GetAllEager()
        {
            return GetEager();
        }

        public Address GetEager(long id)
        {
            return Get(id);
        }
    }

}
