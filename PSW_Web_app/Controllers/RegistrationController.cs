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
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly bolnica.Service.IPatientService _patientService;
        
        public RegistrationController(bolnica.Service.IPatientService s)
        {
            _patientService = s;
        }


        /// <summary>
        ///calls Save(Patient) method from class RegistrationService 
        ///so it can register and save new user in database
        /// </summary>
        /// <returns>status 200 OK response with a registered user</returns>
        [HttpPost]
        public Patient UserRegistration([FromBody] Patient entity)
        {

            //IActionResult actionResult;
            Patient retVal;

            Patient patient = _patientService.CheckExistence(entity.Jmbg,entity.Username,entity.Email);
            if (patient == null)
            {
                String token = GenerateToken();
                entity.VerificationToken = token;
                _patientService.Save(entity);
                SendVerification(entity.Email, entity.Jmbg, token);
                //actionResult = Ok(entity);
                retVal = entity;
            }
            else
            {
                //actionResult = BadRequest(patient);
                retVal = patient;
            }

            return retVal;
        }


        /// <summary>
        /// sends email with autentification token so that user can verify his account
        /// </summary>
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

            //SmtpServer.Send(mail);

        }

        /// <summary>
        /// generate random token 
        /// </summary>
        /// <returns> autentification token to method SendVerification</returns>
        public String GenerateToken()
        {
            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 12)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            string authToken = resultToken.ToString();
            Patient patient = _patientService.GetPatientToken(authToken);
            if(patient != null)
            {
                authToken = GenerateToken();
            }
            return authToken;
        }
    }
}
