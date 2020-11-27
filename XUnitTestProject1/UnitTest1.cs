using System;
using Model.PatientSecretary;
using Moq;
using Xunit;
using bolnica.Repository;
using Repository;
using System.Collections.Generic;
using Service;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Find_drugs()
        {
            var stubRepository = new Mock<IDrugRepository>();
            Ingredient ingr1 = new Ingredient("ingredient1",10);
            Ingredient ingr2 = new Ingredient("ingredient2",5);
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
    }
}
