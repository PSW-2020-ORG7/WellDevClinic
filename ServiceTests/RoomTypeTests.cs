using Model.Director;
using Moq;
using Repository;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ServiceTests
{
    public class RoomTypeTest
    {
        [Fact]
        public void GetAll_ValidArguments_GellAllRoomTypes()
        {
            var roomTypeStubRepository = new Mock<IRoomTypeRepository>();
            var roomTypes = new List<RoomType>();

            RoomType roomTypeOperation = new RoomType(0, "Operation");
            RoomType roomTypeRecovery = new RoomType(1, "Recovery");
            roomTypes.Add(roomTypeOperation);
            roomTypes.Add(roomTypeRecovery);

            roomTypeStubRepository.Setup(r => r.GetAll()).Returns(roomTypes);

            RoomTypeService roomTypeService = new RoomTypeService(roomTypeStubRepository.Object, null);

            List<RoomType> returnedRoomTypes = roomTypeService.GetAll().ToList();

            returnedRoomTypes.ShouldBeEquivalentTo(roomTypes);

        }

        /*
        [Fact]
        public void DeleteRoomType_ValidArguments_DeleteAllRoomsContainingRoomType()
        {
            var roomTypeStubRepository = new Mock<IRoomTypeRepository>();
            var roomStubRepository = new Mock<IRoomRepository>();

            var roomTypes = new List<RoomType>();
            var rooms = new List<Room>();

            RoomType roomTypeOperation = new RoomType(0, "Operation");
            RoomType roomTypeRecovery = new RoomType(1, "Recovery");
            roomTypes.Add(roomTypeOperation);
            roomTypes.Add(roomTypeRecovery);

            Room room1 = new Room(0, "A213", roomTypeOperation, null, 0, 0);
            Room room2 = new Room(0, "A214", roomTypeRecovery, null, 0, 0);
            Room room3 = new Room(0, "A215", roomTypeOperation, null, 0, 0);
            Room room4 = new Room(0, "A216", roomTypeOperation, null, 0, 0);
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);
            rooms.Add(room4);

            roomTypeStubRepository.Setup(r => r.GetAll()).Returns(roomTypes);
            roomStubRepository.Setup(r => r.GetAllEager()).Returns(rooms);
            roomTypeStubRepository.Setup(r => r.Delete(roomTypeOperation));
            

            RoomService roomService = new RoomService(roomStubRepository.Object, null, null, null);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeStubRepository.Object, roomService);


            roomTypeService.Delete(roomTypeOperation);

            List<Room> returnedRooms = new List<Room>();
            returnedRooms.Add(room2);

            rooms = roomService.GetAll().ToList();
            roomTypes = roomTypeService.GetAll().ToList();

            rooms.ShouldBeEquivalentTo(returnedRooms);
        }
        */
    }
}
