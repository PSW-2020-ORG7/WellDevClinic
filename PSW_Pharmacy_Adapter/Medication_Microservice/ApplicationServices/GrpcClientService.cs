using Grpc.Core;
using Microsoft.Extensions.Hosting;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Medication_Microservice.Protos;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices
{
    public class GrpcClientService : IHostedService
    {
        private readonly Channel _channel;
        private readonly SpringGrpcService.SpringGrpcServiceClient _client;

        public GrpcClientService() 
        {
            _channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            _client = new SpringGrpcService.SpringGrpcServiceClient(_channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;



        public async Task<List<Medication>> GetAllMedicationsAmount(string name)
        {
            try
            {
                ProtoResponseMedications response = await _client.communicateMedicationsAsync(new ProtoMedications() { PharmacyName = name });
                List<Medication> meds = new List<Medication>();
                foreach (ProtoMedication m in response.Medication)
                    meds.Add(new Medication(m.Name, m.Amount));
                return meds;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> GetMedicationAmount(string medicationName, string pharmacyName)
        {
            try
            {
                ProtoResponseAvailableMedication response = await _client.communicateAsync(new ProtoAvailableMedication() {MedicationName = medicationName, PharmacyName = pharmacyName});
                return response.Amount;
            }
            catch
            {
                return -408;
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.ShutdownAsync();
            return Task.CompletedTask;
        }
    }
}
