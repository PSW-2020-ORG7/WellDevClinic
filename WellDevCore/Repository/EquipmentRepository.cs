using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class EquipmentRepository : IEquipmentRepository
   {
        private readonly MyDbContext myDbContext;

        public EquipmentRepository(MyDbContext context)
        {
            myDbContext = context;
        }

        public IEnumerable<Equipment> GetAll()
        {
            List<Equipment> result = new List<Equipment>();
            myDbContext.Equipment.ToList().ForEach(equipment => result.Add(equipment));
            return result;
        }

        public void Delete(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public Equipment Get(long id)
            => myDbContext.Equipment.FirstOrDefault(equipment => equipment.Id == id);

        public IEnumerable<Equipment> GetEager()
        {
            List<Equipment> result = new List<Equipment>();
            myDbContext.Equipment.ToList().ForEach(equipment => result.Add(equipment));
            return result;
        }

        public IEnumerable<Equipment> getConsumableEquipment()
        {
            return (IEnumerable<Equipment>) GetEager().Where(equipment => equipment.Type == EquipmentType.Consumable);
        }

        public IEnumerable<Equipment> getInconsumableEquipment()
        {
            return (IEnumerable<Equipment>) GetEager().Where(equipment => equipment.Type == EquipmentType.Inconsumable);
        }

        public Equipment Save(Equipment entity)
        {
            throw new NotImplementedException();
        }
    }
}