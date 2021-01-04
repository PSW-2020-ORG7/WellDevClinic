using RoomManipulation_Microservice.Domain;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly MyDbContext _myDbContext;

        public EquipmentRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Equipment entity)
        {
            _myDbContext.Equipment.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Equipment entity)
        {
            _myDbContext.Equipment.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Equipment Get(long id)
        {
            return _myDbContext.Equipment.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _myDbContext.Equipment.DefaultIfEmpty().ToList();
        }

        public IEnumerable<Equipment> GetConsumableEquipment()
        {
            return _myDbContext.Equipment.Where(e => e.EquipmentType == EquipmentType.Consumable).DefaultIfEmpty().ToList();
        }

        public IEnumerable<Equipment> GetInconsumableEquipment()
        {
            return _myDbContext.Equipment.Where(e => e.EquipmentType == EquipmentType.Inconsumable).DefaultIfEmpty().ToList();
        }

        public Equipment Save(Equipment entity)
        {
            var Equipment = _myDbContext.Equipment.Add(entity);
            _myDbContext.SaveChanges();
            return Equipment.Entity;
        }
    }
}
