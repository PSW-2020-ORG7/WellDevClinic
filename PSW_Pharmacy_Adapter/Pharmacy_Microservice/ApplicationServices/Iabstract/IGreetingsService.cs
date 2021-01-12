using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices.Iabstract
{
    public interface IGreetingsService
    {
        public Task<HttpResponseMessage> GreetPharmacy(string id);
    }
}
