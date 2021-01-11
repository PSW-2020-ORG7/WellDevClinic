using System;
using System.Threading.Tasks;
using Grpc.Core;
using PSW_Pharmacy_Adapter.Medication_Microservice.Protos;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        
        /*public override Task<ProtoResponseAvailableMedication> transfer(ProtoAvailableMedication request, ServerCallContext context)
        {
            Console.WriteLine(request.Message + " from spring; random int: ");
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = true;
            return Task.FromResult(response);
        }*/
    }
}
