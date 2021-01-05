using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class PrescriptionAppService : IPrescriptionAppService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionAppService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public void Delete(Prescription entity)
        {
            _prescriptionRepository.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            _prescriptionRepository.Edit(entity);
        }

        public Prescription Get(long id)
        {
           return _prescriptionRepository.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }

        public Prescription Save(Prescription entity)
        {
            return  _prescriptionRepository.Save(entity);

        }
    }
}
