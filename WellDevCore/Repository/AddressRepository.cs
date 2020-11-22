using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model;
using bolnica.Repository.CSV;
using Model.Users;

namespace bolnica.Repository
{
    public class AddressRepository : CSVGetterRepository<Address, long>, IAddressRepository
    {
        private readonly MyDbContext myDbContext;

        /*public AddressRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public AddressRepository(ICSVStream<Address> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public Address Get(long id)
            => myDbContext.Address.FirstOrDefault(address => address.Id == id);

        public IEnumerable<Address> GetAll()
        {
            List<Address> result = new List<Address>();
            myDbContext.Address.ToList().ForEach(address => result.Add(address));
            return result;
        }

        public IEnumerable<Address> GetAllEager()
        {
            return GetAll();
        }

        public Address GetEager(long id)
        {
            return Get(id);
        }
    }

}
