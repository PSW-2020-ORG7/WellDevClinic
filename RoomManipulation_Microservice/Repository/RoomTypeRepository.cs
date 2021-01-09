using RoomManipulation_Microservice.Domain;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly MyDbContext _myDbContext;

        public RoomTypeRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(RoomType entity)
        {
            _myDbContext.RoomType.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(RoomType entity)
        {
            _myDbContext.RoomType.Update(entity);
            _myDbContext.SaveChanges();
        }

        public RoomType Get(long id)
        {
            return _myDbContext.RoomType.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _myDbContext.RoomType.DefaultIfEmpty().ToList();
        }

        public RoomType Save(RoomType entity)
        {
            var RoomType = _myDbContext.RoomType.Add(entity);
            _myDbContext.SaveChanges();
            return RoomType.Entity;
        }
    }
}
