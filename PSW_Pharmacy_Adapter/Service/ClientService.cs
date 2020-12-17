using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

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

        public async Task<string> SendMessage(string name)
        {
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = name});
                return response.Response;
            }
            catch (Exception exc)
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
