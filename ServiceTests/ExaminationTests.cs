using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.PatientSecretary;
using Moq;
using Repository;
using Service;
using Shouldly;
using Xunit;

namespace ServiceTests
{
    public class ExaminationTests
    {
        [Fact]
        public void Find_drugs()
        {
            var stubRepository = new Mock<IDrugRepository>();
            Ingredient ingr1 = new Ingredient("ingredient1", 10);
            Ingredient ingr2 = new Ingredient("ingredient2", 5);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingr1);
            ingredients.Add(ingr2);
            List<Drug> result = new List<Drug>();
            Drug drug = new Drug(1, "naziv", 3, true, ingredients);
            Drug drug2 = new Drug(2, "naziv2", 4, true, ingredients);
            result.Add(drug);
            result.Add(drug2);
            stubRepository.Setup(m => m.GetEager()).Returns((IEnumerable<Drug>)drug);
            DrugService service = new DrugService(stubRepository.Object);
            Drug d = service.Save(drug2);
            Assert.NotNull(d);
        }

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
    }
}
