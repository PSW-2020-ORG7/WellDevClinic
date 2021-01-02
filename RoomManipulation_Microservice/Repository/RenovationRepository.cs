using RoomManipulation_Microservice.Domain;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Repository
{
    public class RenovationRepository : IRenovationRepository
    {
        private readonly MyDbContext _myDbContext;

        public RenovationRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public void Delete(Renovation entity)
        {
            _myDbContext.Renovation.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void DeleteRenovationByRoom(Room room)
        {
            
        }

        public void Edit(Renovation entity)
        {
            _myDbContext.Renovation.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Renovation Get(long id)
        {
            return _myDbContext.Renovation.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _myDbContext.Renovation.DefaultIfEmpty().ToList();
        }

        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            return _myDbContext.Renovation.Where(r => r.Room.RoomCode == room.RoomCode && r.Period.ComparePeriod(period)).DefaultIfEmpty().ToList();
        }

        public Renovation Save(Renovation entity)
        {
            var Renovation = _myDbContext.Renovation.Add(entity);
            _myDbContext.SaveChanges();
            return Renovation.Entity;
        }
    }
}
