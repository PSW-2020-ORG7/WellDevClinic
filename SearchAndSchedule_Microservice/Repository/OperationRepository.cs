using Microsoft.EntityFrameworkCore;
using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MyDbContext _myDbContext;

        public OperationRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Operation entity)
        {
            _myDbContext.Operation.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Operation entity)
        {
            _myDbContext.Operation.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Operation Get(long id)
        {
            return _myDbContext.Operation.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _myDbContext.Operation.DefaultIfEmpty().ToList();
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            return _myDbContext.Operation.Where(o => o.Doctor.Id == doctor.Id).DefaultIfEmpty().ToList();
        }

        public List<Operation> GetOperationsByRoomAndPeriod(Room room, Period period)
        {
            return _myDbContext.Operation.Where(operation => DateTime.Compare(operation.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(operation.Period.EndDate.Date, period.EndDate.Date) <= 0 && operation.Room.Id == room.Id).DefaultIfEmpty().ToList();
        }

        public Operation Save(Operation entity)
        {
            var Operation = _myDbContext.Operation.Add(entity);
            _myDbContext.SaveChanges();
            return Operation.Entity;
        }
    }
}
