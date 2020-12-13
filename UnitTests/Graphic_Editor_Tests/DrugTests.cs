using bolnica.Service;
using Model.PatientSecretary;
using Moq;
using Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Graphic_Editor_Tests
{
   public class DrugTests
    {

        [Fact]
        public void GetAllDrugExist()
        {
            var drugStubRepository = new Mock<IDrugRepository>();

            Ingredient ingr1 = new Ingredient("ingredient1", 10);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingr1);
            List<Drug> drugs = new List<Drug>();

            Drug drug = new Drug(112, "Brufen", 4, true, ingredients);
            Drug drug1 = new Drug(512, "Aspirin", 4, true, ingredients);
            drugs.Add(drug);
            drugs.Add(drug1);
            drugStubRepository.Setup(r => r.GetAllEager()).Returns(drugs);

            DrugService drugService = new DrugService(drugStubRepository.Object);
            List<Drug> returnedDrugs = drugService.GetAll() as List<Drug>; 

            returnedDrugs.ShouldBeEquivalentTo(drugs);

        }

        [Fact]
        public void GetOneDrugExist()
        {
            var drugStubRepository = new Mock<IDrugRepository>();

            Ingredient ingr1 = new Ingredient("ingredient1", 10);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingr1);


            Drug drug = new Drug(112, "Brufen", 4, true, ingredients);

            drugStubRepository.Setup(r => r.GetEager(112)).Returns(drug);

            DrugService drugService = new DrugService(drugStubRepository.Object);
            Drug returnedDrug = drugService.Get(112);

            returnedDrug.ShouldBeEquivalentTo(drug);
        }

        [Fact]
        public void GetOneDrugNonExist()
        {
            var drugStubRepository = new Mock<IDrugRepository>();

            Ingredient ingr1 = new Ingredient("ingredient1", 10);
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingr1);

            DrugService drugService = new DrugService(drugStubRepository.Object);
            Drug returnedDrug = drugService.Get(113);

            returnedDrug.ShouldBeNull();
        }

    }
}
