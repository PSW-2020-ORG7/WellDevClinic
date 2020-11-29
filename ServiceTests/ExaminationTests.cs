using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.PatientSecretary;
﻿using bolnica.Repository;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Moq;
using Repository;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTests
{
    public class ExaminationTests
    {   [Fact]
        public void GetAll_ValidArguments_GellAllPrescriptions()
        {
            var prescriptionStubRepository = new Mock<IPrescriptionRepository>();
            var prescriptions = new List<Prescription>();
            DateTime StartDate = new DateTime();
            DateTime EndDate = new DateTime();
            Period period = new Period();
            period.StartDate = StartDate;
            period.EndDate = EndDate;
            Ingredient ingr1 = new Ingredient("ingredient1", 10);
            Ingredient ingr2 = new Ingredient("ingredient2", 5);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingr1);
            ingredients.Add(ingr2);
            List<Drug> drugs = new List<Drug>();
            Drug drug = new Drug(1, "naziv", 3, true, ingredients);
            Drug drug2 = new Drug(2, "naziv2", 4, true, ingredients);
            drugs.Add(drug);
            drugs.Add(drug2);
            Prescription prescription1 = new Prescription(0, period,drugs);
            Prescription prescription2 = new Prescription(1, period, drugs);
            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);

            prescriptionStubRepository.Setup(r => r.GetEager()).Returns(prescriptions);

            PrescriptionService prescriptionService = new PrescriptionService(prescriptionStubRepository.Object);

            IEnumerable<Prescription> returnedPrescriptions = prescriptionService.GetAll();
            returnedPrescriptions.ShouldBeEquivalentTo(prescriptions);

        }
        [Fact]
        public void Getting_all_previous_examinatin()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            DateTime today =  DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient1, doctor1, period);
            Patient patient2 = new Patient(1, "Marko", "Markovic");
            Doctor doctor2 = new Doctor(2, "Jovan", "Jovanovic");
            Examination examination2 = new Examination(2, patient2, doctor2, period);
            examinations.Add(examination1);
            examinations.Add(examination2);

            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);

            ExaminationService examinationService = new ExaminationService(null, stubRepository.Object);

            List<Examination> returnedExaminations = examinationService.GetAllPrevious();

            returnedExaminations.ShouldBeEquivalentTo(examinations);
        }

        [Fact]
        public void Not_getting_all_previous_examinatin()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(+1);
            DateTime end = today.AddDays(+1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient1, doctor1, period);
            Patient patient2 = new Patient(1, "Marko", "Markovic");
            Doctor doctor2 = new Doctor(2, "Jovan", "Jovanovic");
            Examination examination2 = new Examination(2, patient2, doctor2, period);
            examinations.Add(examination1);
            examinations.Add(examination2);

            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);

            ExaminationService examinationService = new ExaminationService(null, stubRepository.Object);

            List<Examination> returnedExaminations = examinationService.GetAllPrevious();

            returnedExaminations.ShouldBeEquivalentTo(examinations);
        }
        [Fact]
        public void Getting_all_previous_examinatin_by_user()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient1, doctor1, period);
            examinations.Add(examination1);
         
            stubRepository.Setup(r => r.GetExaminationsByUser(patient1)).Returns(examinations);

            ExaminationService examinationService = new ExaminationService(null, stubRepository.Object);

            List<Examination> returnedExaminations = examinationService.GetFinishedxaminationsByUser(patient1);

            returnedExaminations.ShouldNotBeEmpty();
        }
        [Fact]
        public void Search_examinatin_by_user()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var prescriptionRepository = new Mock<IPrescriptionRepository>();
            var referralRepository = new Mock<IReferralRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            Doctor doctor2 = new Doctor(2, "Jovan", "Jovanovic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Referral referral = new Referral(1, period, doctor2);
            Drug drug = new Drug(1, "aspirin");
            List<Drug> drugs = new List<Drug>();
            drugs.Add(drug);
            Prescription prescription = new Prescription(1, period, drugs);
            Examination examination1 = new Examination(1, patient1, doctor1, period, null, null, null, referral, prescription);
            examinations.Add(examination1);

            stubRepository.Setup(r => r.GetExaminationsByUser(patient1)).Returns(examinations);
            PrescriptionService prescriptionService = new PrescriptionService(prescriptionRepository.Object);
            ReferralService referralService = new ReferralService(referralRepository.Object);
            ExaminationService examinationService = new ExaminationService(null, stubRepository.Object, null, prescriptionService, referralService, null, null);

            List<Examination> returnedExaminations = examinationService.SearchPreviousExamination(DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), "", "", "", patient1);

            returnedExaminations.ShouldNotBeEmpty();
        }

        [Fact]
        public void Search_examinatin_by_user_empty()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var prescriptionRepository = new Mock<IPrescriptionRepository>();
            var referralRepository = new Mock<IReferralRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            Doctor doctor2 = new Doctor(2, "Jovan", "Jovanovic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Referral referral = new Referral(1, period, doctor2);
            Drug drug = new Drug(1, "aspirin");
            List<Drug> drugs = new List<Drug>();
            drugs.Add(drug);
            Prescription prescription = new Prescription(1, period, drugs);
            Examination examination1 = new Examination(1, patient1, doctor1, period, null, null, null, referral, prescription);
            examinations.Add(examination1);

            stubRepository.Setup(r => r.GetExaminationsByUser(patient1)).Returns(examinations);
            PrescriptionService prescriptionService = new PrescriptionService(prescriptionRepository.Object);
            ReferralService referralService = new ReferralService(referralRepository.Object);
            ExaminationService examinationService = new ExaminationService(null, stubRepository.Object, null, prescriptionService, referralService, null, null);

            List<Examination> returnedExaminations = examinationService.SearchPreviousExamination(DateTime.Today.AddDays(+1).ToString("yyyy-MM-dd"), "", "", "", patient1);

            returnedExaminations.ShouldBeEmpty();
        }
    }
}
