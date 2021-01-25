using Model.Director;
using Moq;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using Xunit;
using WellDevCore.Model.Dto;
using Shouldly;
using Model.PatientSecretary;
using bolnica.Service;

namespace UnitTests.Graphic_Editor_Tests
{
    public class RenovationTests
    {
        [Fact]
        public void SaveRenovation()
        {
            var renovationStubRepository = new Mock<IRenovationRepository>();
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);
            Room room = new Room(901);

            List<Period> periods = new List<Period>();
            periods.Add(period);

            Renovation renovation1 = new Renovation(RenovationStatus.Traje, period, "masks", room);
            renovationStubRepository.Setup(r => r.Save(renovation1)).Returns(renovation1);

            RenovationService renovationService = new RenovationService(renovationStubRepository.Object);

            Renovation r = renovationService.Save(renovation1);
            Assert.NotNull(r);
        }

        [Fact]
        public void GetRoomByEquipmentExist()
        {

            var roomStubRepository = new Mock<IRoomRepository>();

            List<Room> rooms = new List<Room>();
            var roomTypes = new List<RoomType>();
            var equipmentDTO = new List<EquipmentDTO>();
            var equipments = new List<Equipment>();

            RoomType roomType1 = new RoomType(900, "Operation");
            roomTypes.Add(roomType1);

            Equipment equipment = new Equipment(801, EquipmentType.Consumable, "masks", 5);
            equipments.Add(equipment);

            EquipmentDTO equipmentDto = new EquipmentDTO(equipment, 5, 333);
            equipmentDTO.Add(equipmentDto);

            Room room = new Room(901, "room1", roomType1, equipmentDTO, 2, 5);
            rooms.Add(room);

            roomStubRepository.Setup(r => r.GetAllEager()).Returns(rooms);

            RoomService roomService = new RoomService(roomStubRepository.Object, null, null, null);
            List<Room> returnedRoom = roomService.GetAll() as List<Room>;

            returnedRoom.ShouldBeEquivalentTo(rooms);

        }


        [Fact]
        public void GetAllRenovationsExist()
        {
            var renovationStubRepository = new Mock<IRenovationRepository>();

            List<Renovation> renovations = new List<Renovation>();

            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);
            Room room = new Room(901);
            Room room1 = new Room(902);

            List<Period> periods = new List<Period>();
            periods.Add(period);

            Renovation renovation = new Renovation(RenovationStatus.Traje, period, "masks", room);
            Renovation renovation1 = new Renovation(RenovationStatus.Zakazano, period, "masks", room1);
            renovations.Add(renovation);
            renovations.Add(renovation1);



            renovationStubRepository.Setup(r => r.GetAllEager()).Returns(renovations);

            RenovationService renovationService = new RenovationService(renovationStubRepository.Object);
            List<Renovation> returnedRenovation = renovationService.GetAll() as List<Renovation>;

            returnedRenovation.ShouldBeEquivalentTo(renovations);

        }

        [Fact]
        public void Edit_Renovation()
        {
            var stubService = new Mock<IRenovationService>();
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);
            Room room = new Room(901);

            List<Period> periods = new List<Period>();
            periods.Add(period);
            Renovation renovation = new Renovation(RenovationStatus.Traje, period, "masks", room);

            stubService.Object.Edit(renovation);

            stubService.Verify(x => x.Edit(It.IsAny<Renovation>()), Times.AtLeastOnce);
        }
    }
}
