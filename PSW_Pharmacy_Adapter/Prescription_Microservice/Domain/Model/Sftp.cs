namespace PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model
{
    public class Sftp
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Sftp(string host, int port, string userName, string password)
        {
            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }
    }
}
