using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WellDevCore.Model.Dto;

namespace Model.Director
{
    public class Room : IIdentifiable<long>
    {
        //[NotMapped] public Dictionary<Equipment, int> Equipment_inventory { get; set; }
        public virtual List<EquipmentDTO> Equipment_inventory { get; set; }

        public string RoomCode { get; set; }

        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public virtual RoomType RoomType { get; set; }

        public int MaxNumberOfPatientsForHospitalization { get; set; }

        public int CurrentNumberOfPatients { get; set; }


        public Room() { }

        public Room(string roomCode, RoomType roomType, List<EquipmentDTO> equipment_inventory, int MaxNumberOfPatientsForHospitalization, int CurrentNumberOfPatients)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            this.RoomType = roomType;
            this.MaxNumberOfPatientsForHospitalization = MaxNumberOfPatientsForHospitalization;
            this.CurrentNumberOfPatients = CurrentNumberOfPatients;
        }

        public Room(long id, string roomCode, RoomType roomType, List<EquipmentDTO> equipment_inventory, int MaxNumberOfPatientsForHospitalization, int CurrentNumberOfPatients)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            Id = id;
            this.RoomType = roomType;
            this.MaxNumberOfPatientsForHospitalization = MaxNumberOfPatientsForHospitalization;
            this.CurrentNumberOfPatients = CurrentNumberOfPatients;
        }

        public Room(long id)
        {
            Id = id;
        }


    }
}
