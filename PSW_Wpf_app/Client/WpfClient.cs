using Newtonsoft.Json;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.Model.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
        
        public static async Task<List<BusinessDay>> GetBussinessdayByDoctor(Doctor doctor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(doctor));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/businessday/GetBusinessDaysByDoctor/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            List<BusinessDay> val = JsonConvert.DeserializeObject<List<BusinessDay>>(value);
            return val;
        }

        public static async Task<BusinessDay> GetExactBusinessdayByDoctor(ExactDayDTO exactDay)
        {
            var content = new StringContent(JsonConvert.SerializeObject(exactDay));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/businessday/GetExactDay/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            BusinessDay val = JsonConvert.DeserializeObject<BusinessDay>(value);
            return val;
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

        public static async Task<UpcomingExamination> NewExamination(UpcomingExamination examination)
        {
            var content = new StringContent(JsonConvert.SerializeObject(examination));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/upcomingexamination/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            UpcomingExamination result = JsonConvert.DeserializeObject<UpcomingExamination>(value);
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
            HttpResponseMessage response = await client.GetAsync("http://localhost:57400/api/room/" + id);
            
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Room room = JsonConvert.DeserializeObject<Room>(responseBody);

            return room;
        }

        public static async Task<Patient> GetPatientByJmbg(string jmbg)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:14483/api/patient/getByJMBG/" + jmbg);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Patient patient = JsonConvert.DeserializeObject<Patient>(responseBody);

            return patient;
        }

        public static async Task<List<Doctor>> GetAllDoctors()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:14483/api/doctor/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Doctor> doctor = JsonConvert.DeserializeObject<List<Doctor>>(responseBody);

            return doctor;
        }

        public static async Task<List<Room>> GetRoomsByEquipment(Equipment equipment)
        {

            var content = new StringContent(JsonConvert.SerializeObject(equipment));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:57400/api/room/GetRoomsCointainingEquipment/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(value);
            return rooms;
        }

        public static async Task<List<Room>> GetAllRooms()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57400/api/room");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(responseBody);

            return rooms;
        }
        public static async Task<List<UpcomingExamination>> GetAllUpcomingExaminations()
        {//ne vraca speciality
            HttpResponseMessage response = await client.GetAsync("http://localhost:62044/api/upcomingexamination");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<UpcomingExamination> examinations = JsonConvert.DeserializeObject<List<UpcomingExamination>>(responseBody);

            return examinations;
        }

        public static async void EditExamination(UpcomingExamination examination)
        {
            var content = new StringContent(JsonConvert.SerializeObject(examination));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PutAsync("http://localhost:62044/api/upcomingexamination/Edit", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
           
        }

        public static async Task<List<BusinessDay>> GetAllBusinessDay()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:62044/api/businessday");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<BusinessDay> businesses = JsonConvert.DeserializeObject<List<BusinessDay>>(responseBody);

            return businesses;
        }
        public static async Task<Renovation> Save(Renovation renovation)
        {

            var content = new StringContent(JsonConvert.SerializeObject(renovation));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:57400/api/renovation/SaveRenovation/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Renovation result = JsonConvert.DeserializeObject<Renovation>(value);
            return result;
        }


        public static async Task MarkAsOccupied(List<Period> period, long id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(period));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/businessday/markAsOccupied/" + id, content);

        }

        public static async Task<List<Renovation>> GetAllRenovation()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:57400/api/renovation");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Renovation> renovations = JsonConvert.DeserializeObject<List<Renovation>>(responseBody);

            return renovations;
        }

        public static async Task<List<UpcomingExamination>> GetExaminationsByRoomAndPeriod(Room room, Period period)
        { 
            ExaminationsByRoomAndPeriodDTO examinations = new ExaminationsByRoomAndPeriodDTO(room, period);
            var content = new StringContent(JsonConvert.SerializeObject(examinations));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:62044/api/upcomingexamination/GetUpcomingExaminationsByRoomAndPeriod/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            List<UpcomingExamination> result = JsonConvert.DeserializeObject<List<UpcomingExamination>>(value);
            return result;

        }

        public static async Task<Patient> SavePatient(Patient patient)
        {
            var content = new StringContent(JsonConvert.SerializeObject(patient));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:14483/api/patient/savePatient/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Patient result = JsonConvert.DeserializeObject<Patient>(value);
            return result;
        }

        public static async Task<List<UpcomingExamination>> GetAllExaminations()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/examination/getAllExaminations");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<UpcomingExamination> examinations = JsonConvert.DeserializeObject<List<UpcomingExamination>>(responseBody);

            return examinations;
        }
    }
}

