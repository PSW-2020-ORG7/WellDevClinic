﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Room : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual List<EquipmentStatistic> EquipmentStatistic { get; set; }
        public String RoomCode { get; set; }
        public virtual RoomType RoomType { get; set; }
        public int MaxNumberOfPatientsForHospitalization { get; set; }
        public int CurrentNumberOfPatients { get; set; }

        public Room(long id, List<EquipmentStatistic> equipmentStatistic, string roomCode, RoomType roomType, int maxNumberOfPatientsForHospitalization, int currentNumberOfPatients)
        {
            Id = id;
            EquipmentStatistic = equipmentStatistic;
            RoomCode = roomCode;
            RoomType = roomType;
            MaxNumberOfPatientsForHospitalization = maxNumberOfPatientsForHospitalization;
            CurrentNumberOfPatients = currentNumberOfPatients;
        }

        public Room()
        {
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
