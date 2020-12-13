using bolnica.Service;
using Model.Director;
using Moq;
using Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Graphic_Editor_Tests
{
    public class EquipmentTests
    {

        [Fact]
        public void GetAllEquipmentExist()
        {

            var equipmentStubRepository = new Mock<IEquipmentRepository>();

            List<Equipment> equipments = new List<Equipment>();

            Equipment equipment = new Equipment(801, EquipmentType.Consumable, "masks", 5);
            Equipment equipment1 = new Equipment(802, EquipmentType.Consumable, "x-ray", 2);
            equipments.Add(equipment);
            equipments.Add(equipment1);
            equipmentStubRepository.Setup(r => r.GetEager()).Returns(equipments);

            EquipmentService equipmentService = new EquipmentService(equipmentStubRepository.Object, null);
            List<Equipment> returnedEquipment = equipmentService.GetAll() as List<Equipment>; 

            returnedEquipment.ShouldBeEquivalentTo(equipments);
   

        }

        [Fact]
        public void GetOneEquipmentExist()
        {
            var equipmentStubRepository = new Mock<IEquipmentRepository>();
            var equipment = new Equipment(801, EquipmentType.Consumable, "masks", 5);

            equipmentStubRepository.Setup(r => r.Get(801)).Returns(equipment);

            EquipmentService equipmentService = new EquipmentService(equipmentStubRepository.Object, null);
            Equipment returnedEquipment = equipmentService.Get(801);

            returnedEquipment.ShouldBeEquivalentTo(equipment);
        }

        [Fact]
        public void GetOneEquipmentNonExist()
        {
            var equipmentStubRepository = new Mock<IEquipmentRepository>();

            EquipmentService equipmentService = new EquipmentService(equipmentStubRepository.Object, null);
            Equipment returnedEquipment = equipmentService.Get(803);

            returnedEquipment.ShouldBeNull();
        }

    }
}
