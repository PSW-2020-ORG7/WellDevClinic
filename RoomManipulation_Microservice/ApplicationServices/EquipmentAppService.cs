using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentAppService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public void Delete(Equipment entity)
        {
            _equipmentRepository.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            _equipmentRepository.Edit(entity);
        }

        public Equipment Get(long id)
        {
            return _equipmentRepository.Get(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public IEnumerable<Equipment> GetConsumableEquipment()
        {
            return _equipmentRepository.GetConsumableEquipment();
        }

        public IEnumerable<Equipment> GetInconsumableEquipment()
        {
            return _equipmentRepository.GetInconsumableEquipment();
        }

        public Equipment Save(Equipment entity)
        {
            return _equipmentRepository.Save(entity);
        }
    }
}
