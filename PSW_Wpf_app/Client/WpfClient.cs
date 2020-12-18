using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_app.Client
{
    public class Equipment
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class Drug
    {
        public String Name { get; set; }
        public long Id { get; set; }
        public int Amount { get; set; }
        public bool Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Drug> Alternative { get; set; }
    }

    public class Doctor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName;
        public string Jmbg;
        public string Email;
        public string Phone;
        public DateTime DateOfBirth;
        //public Address Address;
        public string Username;
        public string Password;
        // public Speciality Specialty;
    }

    public class DoctorDTO
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        // public List<BusinessDayDTO> BusinessDayDTOs { get; set; } = new List<BusinessDayDTO>();
        public String Speciality { get; set; }


    }

    public class BusinessDayDTO
    {
        public long Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public Boolean PatientScheduling = false;
        public BusinessDayDTO(Doctor doctor, Period period)
        {
            this.Doctor = doctor;
            this.Period = period;
        }

        public BusinessDayDTO()
        {

        }

    }

    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ExaminationDTO
    {
       // public long Id { get; set; }
       // public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        //public int RoomId { get; set; }
        // public string Room { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
         public DateTime EndDate { get; set; }
        public Period period;
    }

    public class Room
    {
        public long Id { get; set; }
    }



    static class WpfClient
    {

        static readonly HttpClient client = new HttpClient();

        public static async Task<List<Equipment>> GetAllEquipment()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/equipment");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Equipment> equipments = JsonConvert.DeserializeObject<List<Equipment>>(responseBody);
           
            return equipments;
        }

        public static async Task<List<Drug>> GetAllDrug()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/drug");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Drug> drugs = JsonConvert.DeserializeObject<List<Drug>>(responseBody);

            return drugs;
        }

        public static async Task<List<DoctorDTO>> GetDoctorsBySpeciality(String speciality)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/doctor/" + speciality);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorDTO> doctors = JsonConvert.DeserializeObject<List<DoctorDTO>>(responseBody);

            return doctors;
        }


        public static async Task<List<ExaminationDTO>> FindTerms(BusinessDayDTO businessDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(businessDTO));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/term/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            List<ExaminationDTO> val = JsonConvert.DeserializeObject<List<ExaminationDTO>>(value);
            return val;

        }

    }
}

