using Grpc.Core;
using Microsoft.Extensions.Hosting;
using PSW_Pharmacy_Adapter.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PSW_Pharmacy_Adapter
{
    public class ClientScheduledService : IHostedService
    {
        private System.Timers.Timer timer;
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() 
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(SendMessage);
            timer.Interval = 10000;   
            timer.Enabled = true;
            return Task.CompletedTask;
        }

        private async void SendMessage(object source, ElapsedEventArgs e)
        {
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = "Aspirin"});
                Console.WriteLine("Pharmacy said: " + response.Response + response.Status);          
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
