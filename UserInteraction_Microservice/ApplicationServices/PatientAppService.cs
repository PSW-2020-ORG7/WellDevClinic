using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientAppService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void Delete(Patient entity)
        {
            _patientRepository.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            _patientRepository.Edit(entity);    
        }

        public Patient Get(long id)
        {
            return _patientRepository.Get(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public IEnumerable<Patient> GetAllEager()
        {
            return _patientRepository.GetAllEager();
        }

        public Patient GetEager(long id)
        {
            return _patientRepository.GetEager(id);
        }

        public Patient LogIn(string username, string password)
        {
            return _patientRepository.GetUserByCredentials(username, password);
        }

        public Patient Save(Patient entity)
        {
            return _patientRepository.Save(entity);
        }
    }
}
