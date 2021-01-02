using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MyDbContext _myDbContext;

        public AddressRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Address entity)
        {
            _myDbContext.Address.Remove(entity);
            _myDbContext.SaveChanges();

        }

        public void Edit(Address entity)
        {
            _myDbContext.Address.Update(entity);
            _myDbContext.SaveChanges();
        }

        public IEnumerable<Address> GetAll()
        {
            return _myDbContext.Address.ToList();
        }

        public Address Get(long id)
        {
            return _myDbContext.Address.FirstOrDefault(a => a.Id == id);
        }

        public Address Save(Address entity)
        {
            var Address = _myDbContext.Address.Add(entity);
            _myDbContext.SaveChanges();
            return Address.Entity;
        }
    }
}
