using Model.Director;
using Model.PatientSecretary;
using Moq;
using Repository;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
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

            roomTypeStubRepository.Setup(r => r.GetEager()).Returns(roomTypes);

            RoomTypeService roomTypeService = new RoomTypeService(roomTypeStubRepository.Object, null);

            List<RoomType> returnedRoomTypes = roomTypeService.GetAll().ToList();

            returnedRoomTypes.ShouldBeEquivalentTo(roomTypes);

        }
    }
}
