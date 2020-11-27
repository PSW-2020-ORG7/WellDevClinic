using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using bolnica.Repository.CSV;
using bolnica.Model;

namespace bolnica.Repository
{
    public class TownRepository : ITownRepository
    {
        private readonly IAddressRepository _addressRepository;
        private readonly MyDbContext myDbContext;

        public TownRepository(IAddressRepository addressRepository, MyDbContext context)
        {
            _addressRepository = addressRepository;
            myDbContext = context;
        }

        /*public TownRepository(ICSVStream<Town> stream, ISequencer<long> sequencer, IAddressRepository addressRepository) : base(stream, sequencer)
        {
            _addressRepository = addressRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public Town Get(long id)
            => myDbContext.Town.FirstOrDefault(town => town.Id == id);

        public IEnumerable<Town> GetEager()
        {
            List<Town> result = new List<Town>();
            myDbContext.Town.ToList().ForEach(town => result.Add(town));
            return result;
        }

        public IEnumerable<Town> GetAllEager()
        {
            List<Town> towns = GetEager().ToList();
            for (int i = 0; i < towns.Count; i++)
                towns[i] = GetEager(towns[i].GetId());
            return towns;
        }

        public Town GetEager(long id)
        {
            Town town = Get(id);
            List<Address> addresses = town.GetAddress();
            for (int i = 0; i < addresses.Count; i++)
            {
                addresses[i] = _addressRepository.GetEager(addresses[i].GetId());
            }
            return town;
        }
    }
}
