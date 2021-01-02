using RoomManipulation_Microservice.Domain;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext _myDbContext;

        public RoomRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Room entity)
        {
            _myDbContext.Room.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Room entity)
        {
            _myDbContext.Room.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Room Get(long id)
        {
            return _myDbContext.Room.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _myDbContext.Room.DefaultIfEmpty().ToList();
        }

        public Room Save(Room entity)
        {
            var Room = _myDbContext.Room.Add(entity);
            _myDbContext.SaveChanges();
            return Room.Entity;
        }
    }
}
