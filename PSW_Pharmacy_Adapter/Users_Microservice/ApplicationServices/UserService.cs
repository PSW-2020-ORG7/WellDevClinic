using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Users_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Users_Microservice.Repository.Iabstract;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Users_Microservice.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<User> GetUser(User user)
        {
            string jsonUser = JsonConvert.SerializeObject(user);
            using (HttpContent userContent = new StringContent(jsonUser))
            {
                userContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                User u = JsonConvert.DeserializeObject<User>(
                           (await _clientFactory.CreateClient().PostAsync(Global.hospitalCommunicationLink + "/api/user", userContent))
                           .Content.ReadAsStringAsync().Result);
                if (u == null)
                    return null;
                return u;
            }
        }
    }
}
