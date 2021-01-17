using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_director.Client
{

    public class UserDetails
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Phone { get; set; }
        public String MiddleName { get; set; }
        public String Race { get; set; }
        public String Gender { get; set; }
        public String Email { get; set; }
        public String Image { get; set; }
        public String BloodType { get; set; }
        public virtual Address Address { get; set; }

        public UserDetails() { }
    }

        public enum UserType
    {
        Patient,
        Doctor,
        Secretary,
        Director
    }
    public class User
    {
        public virtual Person Person { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public virtual UserLogIn UserLogIn { get; set; }
        public virtual UserType UserType { get; set; }

        public User(Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;
        }

        public User() { }

    }
    public class UserLogIn
    {
        public long Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public UserLogIn() { }

        public UserLogIn(long id, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();
            Id = id;
            Username = username;
            Password = password;
        }
    }
        public static class WpfDirectorClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<User> GetUser(UserLogIn user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:14483/api/user/login/", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            User userLogged = JsonConvert.DeserializeObject<User>(value);
            return userLogged;
            /*HttpResponseMessage response = await client.PostAsync("http://localhost:14483/api/user" + user);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            User userLogged = JsonConvert.DeserializeObject<User>(responseBody);

            return userLogged;*/
        }

    }
}
