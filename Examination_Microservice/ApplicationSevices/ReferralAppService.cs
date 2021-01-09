using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class ReferralAppService : IReferralAppService
    {
        private readonly IReferralRepository _referralRepository;

        public ReferralAppService(IReferralRepository referralRepository)
        {
            _referralRepository = referralRepository;
        }

        public void Delete(Referral entity)
        {
            _referralRepository.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            _referralRepository.Edit(entity);
        }

        public Referral Get(long id)
        {
            return _referralRepository.Get(id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _referralRepository.GetAll();
        }

        public Referral Save(Referral entity)
        {
            return _referralRepository.Save(entity);

        }
    }
}
