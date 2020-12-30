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

        public Address Get(long id)
        {
            return _myDbContext.Address.Select(a =>
            new Address()
            {
                Id=a.Id,
                Street= a.Street,
                Number=a.Number,
                FullAddress=a.FullAddress,
                Town=new Town(a.Town.Id, a.Town.Name,a.Town.PostalNumber,a.Town.State)
            }

            ).Where(a => a.Id == id).First();
        }

        public IEnumerable<Address> GetAll()
        {
            return _myDbContext.Address.Select(a =>
             new Address()
             {
                 Id = a.Id,
                 Street = a.Street,
                 Number = a.Number,
                 FullAddress = a.FullAddress,
                 Town = new Town(a.Town.Id, a.Town.Name, a.Town.PostalNumber, a.Town.State)
             }

             ).ToList();
        }

        public IEnumerable<Address> GetAllEager()
        {
            return _myDbContext.Address.ToList();
        }

        public Address GetEager(long id)
        {
            return _myDbContext.Address.FirstOrDefault(a => a.Id == id);
        }

        public Address Save(Address entity)
        {
            _myDbContext.Address.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
