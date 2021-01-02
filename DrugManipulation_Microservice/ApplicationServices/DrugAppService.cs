using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using DrugManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.ApplicationServices
{
    public class DrugAppService : IDrugAppService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugAppService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public void Delete(Drug entity)
        {
            _drugRepository.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            _drugRepository.Edit(entity);
        }

        public Drug Get(long id)
        {
            return _drugRepository.Get(id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }

        public Drug Save(Drug entity)
        {
            return _drugRepository.Save(entity);
        }

        public IEnumerable<Drug> GetNotApprovedDrugs()
        {
            return _drugRepository.GetNotApprovedDrugs();
        }
    }
}
