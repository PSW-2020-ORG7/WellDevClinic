using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.DomainServices;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _domainService;
        private readonly IPatientRepository _patientRepository;
        private IConfiguration _config;

        public UserAppService(IUserDomainService domainService, IPatientRepository patientRepository, IConfiguration config)
        {
            _domainService = domainService;
            _patientRepository = patientRepository;
            _config = config;
        }

        public User LogIn(string username, string password)
        {
            return _domainService.LogIn(username, password);
        }

        public User Registration(User user)
        {
            if (user.UserType == UserType.Patient)
            {
                Patient patient = CheckExistence(user.Person.Jmbg, user.UserLogIn.Username, user.UserDetails.Email);
                User retVal;
                if (patient == null)
                {
                    Patient p = (Patient)user; 
                    String token = GenerateToken();
                    p.VerificationToken = token;
                    SendVerification(p.UserDetails.Email, p.Person.Jmbg, token);
                    retVal = _domainService.Registration(user);
                }
                else
                {
                    retVal = patient;
                }
                return retVal;
            }
            else
            {
                return _domainService.Registration(user);
            }
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
               Enumerable.Repeat(allChar, 12)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            string authToken = resultToken.ToString();
            Patient patient = _patientRepository.GetPatientToken(authToken);
            if (patient != null)
            {
                authToken = GenerateToken();
            }
            return authToken;
        }

        public Patient CheckExistence(string jmbg, string username, string email)
        {
            Patient patient = new Patient();

            Patient patientId = _patientRepository.GetPatientByJMBG(jmbg);
            Patient patientEmail = _patientRepository.GetPatientByMail(email);
            Patient patientUsername = _patientRepository.GetPatientByUsername(username);

            if (patientId == null && patientEmail == null && patientUsername == null)
            {
                patient = null;
            }
            else
            {
                if (patientId != null)
                    patient.Person.Jmbg = patientId.Person.Jmbg;
                else if (patientEmail != null)
                    patient.UserDetails.Email = patientEmail.UserDetails.Email;
                /*else if (patientUsername != null)
                    patient.UserLogIn.Username = patientUsername.UserLogIn.Username;*/
            }

            return patient;
        }

        public String GenerateJWT(User user)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(1440);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimUserType = new Claim("type", user.UserType.ToString());
            var claimId = new Claim("Id", user.Person.Id.ToString());
            var claims = new List<Claim>();
            claims.Add(claimUserType);
            claims.Add(claimId);

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
