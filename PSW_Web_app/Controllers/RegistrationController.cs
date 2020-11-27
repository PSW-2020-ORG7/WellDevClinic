using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using bolnica;
using Model.Users;


namespace PSW_Web_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private bolnica.Controller.IPatientController _patientController = new Controller.PatientController();
        

        [HttpPost]
        [Route("new")]
        public IActionResult UserRegistration([FromBody] Patient entity)
        {
            
            IActionResult actionResult;
            
            Patient patient = _patientController.CheckExistence(entity.Jmbg,entity.Username,entity.Email);
            if (patient == null)
            {
                String token = GenerateToken();
                entity.VerificationToken = token;
                SendVerification(entity.Email, entity.Jmbg, token);
                actionResult = Ok(entity);
            }
            else
            {
                actionResult = BadRequest(patient);
            }

            return actionResult;
        }



        public void SendVerification(String email, String jmbg, String authToken)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("hospitalservicePSW@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Verification Mail";
            String token = "http://localhost:49153/html/login.html/" + authToken;
            mail.Body = "A verification link has been sent to your email account. " +
                "Please click on the link to verify your account and finish registration process. " + token;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hospitalservicePSW@gmail.com", "hospitalservicePSW1998");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public String GenerateToken()
        {
            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 8)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            string authToken = resultToken.ToString();
            return authToken;
        }
    }
}
