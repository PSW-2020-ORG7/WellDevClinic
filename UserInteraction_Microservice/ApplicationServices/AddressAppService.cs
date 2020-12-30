using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressAppService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Delete(Address entity)
        {
            _addressRepository.Delete(entity);
        }

        public void Edit(Address entity)
        {
            _addressRepository.Edit(entity);
        }

        public Address Get(long id)
        {
           return  _addressRepository.Get(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public IEnumerable<Address> GetAllEager()
        {
            return _addressRepository.GetAllEager();
        }

        public Address GetEager(long id)
        {
            return _addressRepository.GetEager(id);
        }

        public Address Save(Address entity)
        {
            return _addressRepository.Save(entity);
        }
    }
}
