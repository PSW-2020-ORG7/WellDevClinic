using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ExaminationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<Examination>> GetAllExaminations()
        => JsonConvert.DeserializeObject<List<Examination>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/examination/getAll"))
                           .Content.ReadAsStringAsync().Result);
    }
}
