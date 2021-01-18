using Newtonsoft.Json;
using PSW_Wpf_app.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_app.Client
{
  
    public class ExaminationDTO
    {
       
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public Period Period { get; set; }

        public ExaminationDTO(Doctor doctor, Period period, Patient patient) 
        {
            Doctor = doctor;
            Period = period;
            Patient = patient;
        }
        public ExaminationDTO()
        {
        }
    }

    public class Examination
    {
        public long Id { get; set; }
        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public Period Period { get; set; }
        public Patient Patient { get; set; }

        public Examination(Patient patient, Doctor doctor, Period period)
        {
            Patient = patient;
            Doctor = doctor;
            Period = period;
        }
    }

    public class User:Person
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Image { get; set; }
        public long Id { get; set; }

    }

    public abstract class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public long Id { get; set; }
    }


   

    public class Renovation
    {

        public string Description { get; set; }
        public virtual RenovationStatus Status { get; set; }

        public virtual Period Period { get; set; }

        public virtual Room Room { get; set; }

        public long Id { get; set; }


        public Renovation(long id, RenovationStatus status, Period period, string description, Room room)
        {
            Id = id;
            Status = status;
            Period = period;
            Description = description;
            Room = room;
        }

        public Renovation()
        {

            Status = RenovationStatus.Traje;

        }
    }

    public enum RenovationStatus
    {
        [Description("U toku")]
        Traje,
        [Description("Zavrseno")]
        Zavrseno,
        [Description("Zakazano")]
        Zakazano,
        [Description("Otkazano")]
        Otkazano,

    }

    public class PatientFile
    {
        public virtual List<Examination> Examination { get; set; }
        public long Id { get; set; }
    }



    static class WpfClient
    {

        static readonly HttpClient client = new HttpClient();

        public static async Task<List<Equipment>> GetAllEquipment()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57400/api/equipment");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Equipment> equipments = JsonConvert.DeserializeObject<List<Equipment>>(responseBody);
           
            return equipments;
        }

        public static async Task<List<Drug>> GetAllDrug()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51891/api/drug");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Drug> drugs = JsonConvert.DeserializeObject<List<Drug>>(responseBody);

            return drugs;
        }

        public static async Task<BusinessDay> GetBussinessdayByDoctor(Doctor doctor)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:62044/api/businessday/GetBusinessDaysByDoctor/" + doctor);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            BusinessDay buss = JsonConvert.DeserializeObject<BusinessDay>(responseBody);

            return buss;
        }

        public static async Task<List<Doctor>> GetDoctorsBySpeciality(String speciality)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:14483/api/doctor/getBySpeciality/" + speciality);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(responseBody);

            return doctors;
        }

        public static async Task<List<Speciality>> GetAllSpeciality()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:14483/api/speciality");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Speciality> specs = JsonConvert.DeserializeObject<List<Speciality>>(responseBody);

            return specs;
        }



        public static async Task<List<ExaminationDTO>> FindTerms(BusinessDayDTO businessDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(businessDTO));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/businessday/Search/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            List<ExaminationDTO> val = JsonConvert.DeserializeObject<List<ExaminationDTO>>(value);
            return val;

        }

        public static async Task<Examination> NewExamination(ExaminationDTO examination)
        {
            var content = new StringContent(JsonConvert.SerializeObject(examination));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/examination/newExamination/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Examination result = JsonConvert.DeserializeObject<Examination>(value);
            return result;
        }

        public static async Task<List<Patient>> GetAllPatient()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:14483/api/patient");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(responseBody);

            return patients;
        }
        
        public static async Task<Room> GetRoomById(long id)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/room/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Room room = JsonConvert.DeserializeObject<Room>(responseBody);

            return room;
        }

        public static async Task<Patient> GetPatientByJmbg(string jmbg)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/patient/patientJmbg/" + jmbg);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Patient patient = JsonConvert.DeserializeObject<Patient>(responseBody);

            return patient;
        }

        public static async Task<List<Doctor>> GetAllDoctors()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/doctor/getAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Doctor> doctor = JsonConvert.DeserializeObject<List<Doctor>>(responseBody);

            return doctor;
        }

        public static async Task<List<Room>> GetRoomsByEquipment(long equipmentId)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/room/GetRoomByEquipment/" + equipmentId);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(responseBody);

            return rooms;
        }

        public static async Task<List<Room>> GetAllRooms()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/room");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(responseBody);

            return rooms;
        }
        public static async Task<List<Examination>> GetAllUpcomingExaminations()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/examination/getAllUpcoming");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Examination> examinations = JsonConvert.DeserializeObject<List<Examination>>(responseBody);

            return examinations;
        }

        public static async void EditExamination(Examination examination)
        {
            var content = new StringContent(JsonConvert.SerializeObject(examination));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:51393/api/examination/changePatient", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
           
        }
        public static async Task<List<Examination>> GetExaminationsByRoomAndPeriod(long roomId, DateTime dateTime)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/examination/" + roomId + "/" + dateTime.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Examination> exams = JsonConvert.DeserializeObject<List<Examination>>(responseBody);

            return exams;
        }

        public static async Task<List<BusinessDay>> GetAllBusinessDay()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/businessday");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<BusinessDay> businesses = JsonConvert.DeserializeObject<List<BusinessDay>>(responseBody);

            return businesses;
        }

        public static async Task<Renovation> Save(Renovation entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/renovation/save/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Renovation result = JsonConvert.DeserializeObject<Renovation>(value);
            return result;
        }


        public static async Task MarkAsOccupied(List<Period> period, long id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(period));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/renovation/markAsOccupied/" + id, content);

        }

        public static async Task<List<Renovation>> GetAllRenovation()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/renovation");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Renovation> renovations = JsonConvert.DeserializeObject<List<Renovation>>(responseBody);

            return renovations;
        }

        public static async Task<List<Examination>> GetExaminationsByRoomAndPeriodForAlternative(long roomId, DateTime dateTime1, DateTime dateTime2)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/examination/" + roomId + "/" + dateTime1.ToString() + "/" + dateTime2.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Examination> exams = JsonConvert.DeserializeObject<List<Examination>>(responseBody);

            return exams;
        }

        public static async Task<Patient> SavePatient(Patient patient)
        {
            var content = new StringContent(JsonConvert.SerializeObject(patient));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/patient/savePatient/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Patient result = JsonConvert.DeserializeObject<Patient>(value);
            return result;
        }
    }
}

