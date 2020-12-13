using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ReferralService : IReferralService
    {
        private IReferralRepository _referralRepository;

        public ReferralService(IReferralRepository repository)
        {
            _referralRepository = repository;
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
            return _referralRepository.GetEager();
        }

        public Referral Save(Referral entity)
        {
            return _referralRepository.Save(entity);
        }

        public Boolean CheckSpecialist(String specialistName, Referral referral)
        {
            if (specialistName == "")
                return false;
            String specialist = referral.Doctor.Specialty.Name;
            return specialist.ToLower().Contains(specialistName.ToLower());
        }

        public Boolean CheckText(String text, Referral referral)
        {
            if (text == "")
            {
                return false;
            }
            String ref_text = referral.Text.ToLower();
            return ref_text.Contains(text.ToLower());
        }
    }
}