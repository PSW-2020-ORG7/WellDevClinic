using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Protos;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter
{
    public class ClientService : IHostedService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientService() 
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;


        public async Task<List<string>> getMedications(string name)
        {
            List<string> medications = new List<string>();
            ProtoResponseMedications response = await client.communicateMedicationsAsync(new ProtoMedications() {PharmacyName = name });
            return new List<string>(response.MedicationName);
            
        }

        public async Task<string> SendMessage(string medicationName, string pharmacyName)
        {
            try
            {
                ProtoResponseAvailableMedication response = await client.communicateAsync(new ProtoAvailableMedication() {MedicationName = medicationName, PharmacyName = pharmacyName});
                return response.Response;
            }
            catch
            {
                return "Try again later.";
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            return Task.CompletedTask;
        }
    }
}
