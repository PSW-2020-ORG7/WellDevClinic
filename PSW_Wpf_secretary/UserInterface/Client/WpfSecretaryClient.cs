using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSW_Wpf_secretary.Client
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }

    }
    public static class WpfSecretaryClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<Secretary> GetUser(string username, string password)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new LoginModel { username = username, password = password }));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/user", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Secretary user = JsonConvert.DeserializeObject<Secretary>(value);

            return user;
        }
    }
}
