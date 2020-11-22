using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class DrugRepository : CSVRepository<Drug, long>, IDrugRepository, IEagerRepository<Drug,long>
   {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly MyDbContext myDbContext;

        /*public DrugRepository(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public DrugRepository(ICSVStream<Drug> stream, ISequencer<long> sequencer, IIngredientRepository ingredientRepository)
    : base(stream, sequencer)
        {
            _ingredientRepository = ingredientRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public IEnumerable<Drug> GetAllEager()
        {
            IEnumerable<Drug> drugs = this.GetAll();
            IEnumerable<Ingredient> ingredients = _ingredientRepository.GetAll();
            BindDrugIngredients(drugs, ingredients);
            BindAlternativeDrugs(drugs);

            return drugs;
        }

        private void BindAlternativeDrugs(IEnumerable<Drug> drugs)
        {
            foreach (Drug drug in drugs.ToList())
            {
                foreach (Drug alternativeDrug in drug.Alternative)
                {
                    Drug temp = Get(alternativeDrug.Id);
                    alternativeDrug.Name = temp.Name;
                    alternativeDrug.Amount = temp.Amount;
                    alternativeDrug.Approved = temp.Approved;
                }
            }
        }

        private void BindDrugIngredients(IEnumerable<Drug> drugs, IEnumerable<Ingredient> ingredients)
        {
            drugs = drugs.ToList();
            ingredients = ingredients.ToList();
            foreach (Drug drug in drugs)
            {
                foreach(Ingredient ingredient in drug.Ingredients)
                {
                    Ingredient temp = ingredients.SingleOrDefault(ing => ing.GetId() == ingredient.GetId());
                    ingredient.Name = temp.Name;
                    ingredient.Quantity = temp.Quantity;
                }
            }
        }

        public Drug GetEager(long id)
        {
            Drug drug = Get(id);
            foreach (Ingredient ingredient in drug.Ingredients)
            {
                Ingredient temp = _ingredientRepository.Get(ingredient.Id);
                ingredient.Name = temp.Name;
                ingredient.Quantity = temp.Quantity;
            }

            foreach (Drug alternativeDrug in drug.Alternative)
            {
                Drug temp = Get(id);
                alternativeDrug.Name = temp.Name;
                alternativeDrug.Amount = temp.Amount;
                alternativeDrug.Approved = temp.Approved;
            }

            return drug;
        }

        public List<Drug> GetNotApprovedDrugs()
        {
            List<Drug> notApprovedDrugs = new List<Drug>();
            IEnumerable<Drug> drugs = this.GetAll();
            foreach (Drug drug in drugs.ToList())
            {
                if (drug.Approved == false)
                {
                    notApprovedDrugs.Add(drug);
                }
            }
                return notApprovedDrugs;
        }

        public Drug Save(Drug entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Drug entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Drug entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drug> GetAll()
        {
            List<Drug> result = new List<Drug>();
            myDbContext.Drug.ToList().ForEach(drug => result.Add(drug));
            return result;
        }

        public Drug Get(long id)
            => myDbContext.Drug.FirstOrDefault(drug => drug.Id == id);
    }
}