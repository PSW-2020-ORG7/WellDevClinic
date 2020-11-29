using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class RenovationRepository :  IRenovationRepository
   {
        public IRoomRepository _roomRepository;
        private readonly MyDbContext myDbContext;

        public RenovationRepository(IRoomRepository roomRepository, MyDbContext context)
        {
            _roomRepository = roomRepository;
            myDbContext = context;
        }

        public IEnumerable<Renovation> GetAllEager()
        {
            IEnumerable<Renovation> renovations = GetEager();
            IEnumerable<Room> rooms = _roomRepository.GetAllEager();
            BindRenovationWithRoom(renovations, rooms);

            return renovations;
        }

        private void BindRenovationWithRoom(IEnumerable<Renovation> renovations, IEnumerable<Room> rooms)
            => renovations.ToList().ForEach(renovation => renovation.Room = GetRoomByID(rooms, renovation.Room.GetId()));

        private Room GetRoomByID(IEnumerable<Room> rooms, long Id)
            => rooms.SingleOrDefault(room => room.GetId() == Id);

        public Renovation GetEager(long id)
        {
            Renovation renovation = Get(id);
            renovation.Room = _roomRepository.GetEager(renovation.Room.GetId());

            return renovation;
            
        }

        public Renovation Save(Renovation entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Renovation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Renovation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Renovation> GetEager()
        {
            throw new NotImplementedException();
        }

        public Renovation Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}