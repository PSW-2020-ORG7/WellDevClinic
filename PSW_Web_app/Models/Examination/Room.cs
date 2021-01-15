using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models.Examination
{
    public class Room : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String RoomCode { get; set; }
        public virtual RoomType RoomType { get; set; }
        public int MaxNumberOfPatientsForHospitalization { get; set; }
        public int CurrentNumberOfPatients { get; set; }

        public Room() { }

        public Room(long id, string roomCode, RoomType roomType, int maxNumberOfPatientsForHospitalization, int currentNumberOfPatients)
        {
            Id = id;
            RoomCode = roomCode;
            RoomType = roomType;
            MaxNumberOfPatientsForHospitalization = maxNumberOfPatientsForHospitalization;
            CurrentNumberOfPatients = currentNumberOfPatients;
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
