using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Decorators
{
    public class AuthorityEquipmentDecorator : IEquipmentAppService
    {
        private readonly IEquipmentAppService _equipmentAppService;
        public String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityEquipmentDecorator(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director" },
                ["GetAll"] = new List<string>() { "Director" },
                ["GetConsumableEquipment"] = new List<string>() { "Director" },
                ["GetInconsumableEquipment"] = new List<string>() { "Director" },
                ["Save"] = new List<string>() { "Director" }
            };

        }


        public void Delete(Equipment entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _equipmentAppService.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _equipmentAppService.Edit(entity);
        }

        public Equipment Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _equipmentAppService.Get(id);
            return null;
        }

        public IEnumerable<Equipment> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _equipmentAppService.GetAll();
            return null;
        }

        public IEnumerable<Equipment> GetConsumableEquipment()
        {
            if (AuthorizedUsers["GetConsumableEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _equipmentAppService.GetConsumableEquipment();
            return null;
        }

        public IEnumerable<Equipment> GetInconsumableEquipment()
        {
            if (AuthorizedUsers["GetInconsumableEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _equipmentAppService.GetInconsumableEquipment();
            return null;
        }

        public Equipment Save(Equipment entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _equipmentAppService.Save(entity);
            return null;
        }

    }
}
