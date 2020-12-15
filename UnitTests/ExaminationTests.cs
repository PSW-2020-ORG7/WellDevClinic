using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.PatientSecretary;

using Model.Doctor;

using Model.Users;
using Moq;
using Repository;
using Service;
using Shouldly;

using Xunit;

namespace UnitTests
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

        private static IExaminationPreviousRepository CreateStubRepositoryExaminationPrevious() {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient1, doctor1, period);
            Patient patient2 = new Patient(3, "Marko", "Markovic");
            Doctor doctor2 = new Doctor(4, "Jovan", "Jovanovic");
            Examination examination2 = new Examination(2, patient2, doctor2, period);
            examinations.Add(examination1);
            examinations.Add(examination2);

            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);
            return stubRepository.Object;
        }

        private static IExaminationUpcomingRepository CreateStubRepositoryExaminationUpcoming()
        {
            var stubRepository = new Mock<IExaminationUpcomingRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(1);
            DateTime end = today.AddDays(1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient1, doctor1, period);
            Patient patient2 = new Patient(3, "Marko", "Markovic");
            Doctor doctor2 = new Doctor(4, "Jovan", "Jovanovic");
            Examination examination2 = new Examination(2, patient2, doctor2, period);
            examinations.Add(examination1);
            examinations.Add(examination2);

            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);
            return stubRepository.Object;
        }

        private static IExaminationPreviousRepository CreateStubRepositoryExamination() {
            var stubRepository = new Mock<IExaminationPreviousRepository>();
            var examinations = new List<Examination>();

            Patient patient1 = new Patient(1, "Pera", "Peric");
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            Doctor doctor2 = new Doctor(3, "Jovan", "Jovanovic");
            doctor1.Specialty = new Speciality("hirurg");
            DateTime today = DateTime.Today;
            DateTime start = today.AddDays(-1);
            DateTime end = today.AddDays(-1);
            Period period = new Period(start, end);
            Referral referral = new Referral(1, period, doctor1);
            Drug drug = new Drug(1, "aspirin");
            List<Drug> drugs = new List<Drug>();
            drugs.Add(drug);
            Prescription prescription = new Prescription(1, period, drugs);
            Examination examination1 = new Examination(1, patient1, doctor1, period, null, null, null, referral, prescription);
            examinations.Add(examination1);

            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);
            return stubRepository.Object;

        }

        [Fact]
        public void Getting_all_previous_examinations()
        {
            ExaminationService examinationService = new ExaminationService(null, CreateStubRepositoryExaminationPrevious());

            List<Examination> returnedExaminations = examinationService.GetAllPrevious();

            returnedExaminations.ShouldNotBeEmpty();
        }

        [Fact]
        public void Getting_all_previous_examinations_by_user()
        {

            ExaminationService examinationService = new ExaminationService(null, CreateStubRepositoryExaminationPrevious());

            List<Examination> returnedExaminations = examinationService.GetFinishedExaminationsByUser(1);

            returnedExaminations.ShouldNotBeEmpty();
        }
        [Fact]
        public void Getting_all_previous_examinations_by_user_failed()
        {
            ExaminationService examinationService = new ExaminationService(null, CreateStubRepositoryExaminationPrevious());

            List<Examination> returnedExaminations = examinationService.GetFinishedExaminationsByUser(5);

            returnedExaminations.ShouldBeEmpty();
        }

        [Fact]
        public void Getting_all_upcoming_examinations()
        {
            ExaminationService examinationService = new ExaminationService( CreateStubRepositoryExaminationUpcoming(), null);

            List<Examination> returnedExaminations = (List<Examination>)examinationService.GetAll();

            returnedExaminations.ShouldNotBeEmpty();
        }

        [Fact]
        public void Getting_all_upcoming_examinations_by_user()
        {
            ExaminationService examinationService = new ExaminationService(CreateStubRepositoryExaminationUpcoming(), null);

            List<Examination> returnedExaminations = (List<Examination>)examinationService.GetUpcomingExaminationsByUser(3);

            returnedExaminations.ShouldNotBeEmpty();
        }

        [Fact]
        public void Getting_all_upcoming_examinations_by_user_failed()
        {
            ExaminationService examinationService = new ExaminationService(CreateStubRepositoryExaminationUpcoming(), null);

            List<Examination> returnedExaminations = (List<Examination>)examinationService.GetUpcomingExaminationsByUser(5);

            returnedExaminations.ShouldBeEmpty();
        }

        [Fact]
        public void GetAllReferrals()
        {
            var referralStubRepository = new Mock<IReferralRepository>();
            var referrals = new List<Referral>();
            DateTime StartDate = new DateTime();
            DateTime EndDate = new DateTime();
            Period period = new Period();
            period.StartDate = StartDate;
            period.EndDate = EndDate;
            Doctor doctor1 = new Doctor(2, "Eva", "Evic");
            Doctor doctor2 = new Doctor(2, "Jovan", "Jovanovic");
            Referral referral1 = new Referral(0, period, doctor1);
            Referral referral2 = new Referral(1, period, doctor2);
            referrals.Add(referral1);
            referrals.Add(referral2);
            referralStubRepository.Setup(r => r.GetEager()).Returns(referrals);
            ReferralService referralService = new ReferralService(referralStubRepository.Object);
            IEnumerable<Referral> returnedReferrals = referralService.GetAll();
            returnedReferrals.ShouldBeEquivalentTo(referrals);
        }
    }
}
