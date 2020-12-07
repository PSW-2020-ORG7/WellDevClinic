using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Repository
{
    public class RoomRepository : IRoomRepository, IEagerRepository<Room, long>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly MyDbContext myDbContext;

        public RoomRepository(IRoomTypeRepository roomTypeRepository, IEquipmentRepository equipmentRepository,MyDbContext context)
        {
            _roomTypeRepository = roomTypeRepository;
            _equipmentRepository = equipmentRepository;
            myDbContext = context;
            
        }

        /*public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer, IRoomTypeRepository roomTypeRepository, IEquipmentRepository equipmentRepository)
     : base(stream, sequencer)
        {
            _roomTypeRepository = roomTypeRepository;
            _equipmentRepository = equipmentRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public IEnumerable<Room> GetAllEager()
        {
            IEnumerable<Room> rooms = this.GetEager();
            IEnumerable<RoomType> roomTypes = _roomTypeRepository.GetEager();
            IEnumerable<Equipment> equipment = _equipmentRepository.GetEager();
            BindRoomsWithRoomTypes(rooms, roomTypes);
            BindRoomsWithEquipment(rooms, equipment);

            return rooms;
        }

        private void BindRoomsWithEquipment(IEnumerable<Room> rooms, IEnumerable<Equipment> equipment)
        {
            rooms = rooms.ToList();
            equipment = equipment.ToList();
            foreach (Room room in rooms)
            {
                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    Equipment temp = equipment.SingleOrDefault(eq => eq.GetId() == pair.Key.GetId());
                    if (temp != default)
                    {
                        pair.Key.Name = temp.Name;
                        pair.Key.Type = temp.Type;
                        pair.Key.Amount = temp.Amount;
                    }
                }
            }
        }

        private void BindRoomsWithRoomTypes(IEnumerable<Room> rooms, IEnumerable<RoomType> roomTypes)
            => rooms.ToList().ForEach(room => room.RoomType = GetRoomTypeByID(roomTypes, room.RoomType.GetId()));

        private RoomType GetRoomTypeByID(IEnumerable<RoomType> roomTypes, long Id)
            => roomTypes.SingleOrDefault(roomType => roomType.GetId() == Id);

        public Room GetEager(long id)
        {
            Room room = myDbContext.Room.Find(id);
            room.RoomType = _roomTypeRepository.Get(room.RoomType.GetId());

            foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
            {
                Equipment temp = _equipmentRepository.Get(pair.Key.Id);
                pair.Key.Name = temp.Name;
                pair.Key.Type = temp.Type;
                pair.Key.Amount = temp.Amount;
            }
            return room;
        }

        public Room Save(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetEager()
        {
            List<Room> result = new List<Room>();
            myDbContext.Room.ToList().ForEach(room => result.Add(room));
            return result;
        }

        public Room Get(long id)
            => myDbContext.Room.FirstOrDefault(room => room.Id == id);
    }
}
