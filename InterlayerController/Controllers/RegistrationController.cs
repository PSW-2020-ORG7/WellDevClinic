﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.Users;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IPatientController _patientController;

        public RegistrationController(IPatientController patientController)
        {
            _patientController = patientController;
        }


        /// <summary>
        ///calls Save(Patient) method from class RegistrationService 
        ///so it can register and save new user in database
        /// </summary>
        /// <returns>status 200 OK response with a registered user</returns>
        [HttpPost]
        public Patient UserRegistration([FromBody] Patient entity)
        {
            Patient retVal;

            Patient patient = _patientController.CheckExistence(entity.Jmbg, entity.Username, entity.Email);
            if (patient == null)
            {
                String token = GenerateToken();
                entity.VerificationToken = token;
                _patientController.Save(entity);
                SendVerification(entity.Email, entity.Jmbg, token);
                retVal = entity;
            }
            else
            {
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

            SmtpServer.Send(mail);

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
            Patient patient = _patientController.GetPatientToken(authToken);
            if (patient != null)
            {
                authToken = GenerateToken();
            }
            return authToken;
        }
    }
}
