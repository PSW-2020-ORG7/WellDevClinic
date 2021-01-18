using System;

namespace PSW_Pharmacy_Adapter
{
    public static class Global
    {
        public static readonly string hospitalCommunicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";
        public static readonly string drugCommunicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51891";
        public static readonly string ErrorMessage = "Something went wrong, try again later.";
        public static readonly string ErrorSftp = "Server for file transfer is unavilable, try again later.";
    }
}
