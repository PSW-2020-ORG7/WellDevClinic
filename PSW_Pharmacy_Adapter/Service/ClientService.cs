using Grpc.Core;
using Microsoft.Extensions.Hosting;
using PSW_Pharmacy_Adapter.Protos;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Model;
using System;

namespace PSW_Pharmacy_Adapter
{
    public class ClientService : IHostedService
    {
        private readonly Channel _channel;
        private readonly SpringGrpcService.SpringGrpcServiceClient _client;

        public ClientService() 
        {
            _channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            _client = new SpringGrpcService.SpringGrpcServiceClient(_channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;


        public async Task<object> GetMedications(string name)
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
                return Global.ErrorMessage;
            }
        }

        public async Task<object> SendMessage(string medicationName, string pharmacyName)
        {
            try
            {
                ProtoResponseAvailableMedication response = await _client.communicateAsync(new ProtoAvailableMedication() {MedicationName = medicationName, PharmacyName = pharmacyName});
                return response.Amount;
            }
            catch
            {
                return Global.ErrorMessage;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel?.ShutdownAsync();
            return Task.CompletedTask;
        }
    }
}
