using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository
{
    public class BussinesDayRepository : IBussinesDayRepository
    {
        private readonly MyDbContext _myDbContext;

        public BussinesDayRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(BusinessDay entity)
        {
            _myDbContext.BussinesDay.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void DeleteRange(List<BusinessDay> businessDays)
        {
            _myDbContext.BussinesDay.RemoveRange(businessDays);
            _myDbContext.SaveChanges();
        }

        public void Edit(BusinessDay entity)
        {
            _myDbContext.BussinesDay.Update(entity);
            _myDbContext.SaveChanges();
        }

        public BusinessDay Get(long id)
        {
            return _myDbContext.BussinesDay.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            return _myDbContext.BussinesDay.DefaultIfEmpty().ToList();
        }

        public IEnumerable<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            return _myDbContext.BussinesDay.Where(b => b.Doctor.Id == doctor.Id).ToList().DefaultIfEmpty();
        }

        public IEnumerable<BusinessDay> GetBusinessDaysByRoom(Room room)
        {
            return _myDbContext.BussinesDay.Where(b => b.Room.Id == room.Id).ToList().DefaultIfEmpty();
        }

        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
            return _myDbContext.BussinesDay.FirstOrDefault(b => b.Doctor.Id == doctor.Id && b.Shift.StartDate.Date == date.Date);
        }

        public BusinessDay Save(BusinessDay entity)
        {
            var BussinesDay = _myDbContext.BussinesDay.Add(entity);
            _myDbContext.SaveChanges();
            return BussinesDay.Entity;
        }
    }
}
