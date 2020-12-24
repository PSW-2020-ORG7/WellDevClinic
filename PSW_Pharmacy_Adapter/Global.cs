using System;

namespace PSW_Pharmacy_Adapter
{
    public static class Global
    {
        public static string hospitalCommunicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";
        public static string ErrorMessage = "Something went wrong, try again later.";
        public static string ErrorSftp = "Sftp server is unavilable, try again later.";
    }
}
