using System;

namespace PSW_Pharmacy_Adapter
{
    public static class Global
    {
        public static string hospitalCommunicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";
    }
}
