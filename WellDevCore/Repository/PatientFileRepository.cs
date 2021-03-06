using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{

    public class PatientFileRepository : IPatientFileRepository
    {
        public IHospitalizationRepository _hospitalizationRepository;
        public IOperationRepository _operationRepository;
        public IExaminationPreviousRepository _examinationPreviousRepository;
        private readonly MyDbContext myDbContext;

        public PatientFileRepository(IHospitalizationRepository hospitalizationRepository, IOperationRepository operationRepository, IExaminationPreviousRepository examinationPreviousRepository, MyDbContext context)
        {
            _hospitalizationRepository = hospitalizationRepository;
            _operationRepository = operationRepository;
            _examinationPreviousRepository = examinationPreviousRepository;
            myDbContext = context;
        }

        public PatientFileRepository(MyDbContext myDbContext) 
        {
            this.myDbContext = myDbContext;
        }


        public PatientFileRepository()
        {
        }


        public PatientFile GetEager(long id)
        {
            PatientFile patientFile = Get(id);
            List<Hospitalization> hospitalizatonCollection = new List<Hospitalization>();
            if (patientFile.Hospitalization != null)
            {
                foreach (Hospitalization hospitalization in patientFile.Hospitalization)
                {
                    hospitalizatonCollection.Add(_hospitalizationRepository.GetEager(hospitalization.GetId()));
                }
            }
            patientFile.Hospitalization = hospitalizatonCollection;
            List<Operation> operationCollection = new List<Operation>();
            if (patientFile.Operation != null)
            {
                foreach (Operation operation in patientFile.Operation)
                {
                    operationCollection.Add(_operationRepository.GetEager(operation.GetId()));
                }
            }
            patientFile.Operation = operationCollection;
            List<Examination> examinationCollection = new List<Examination>();
            if (patientFile.Examination != null)
            {
                foreach (Examination examination in patientFile.Examination)
                {
                    examinationCollection.Add(_examinationPreviousRepository.GetEager(examination.GetId()));
                }
            }
            patientFile.Examination = examinationCollection;
            return patientFile;
        }

        public PatientFile Save(PatientFile entity)
        {
            throw new NotImplementedException();
        }

    

        public void Edit(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PatientFile entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientFile> GetEager()
        {
            List<PatientFile> result = new List<PatientFile>();
            myDbContext.PatientFile.ToList().ForEach(patientFile => result.Add(patientFile));
            return result;
        }

        public PatientFile Get(long id)
            => myDbContext.PatientFile.FirstOrDefault(patientFile => patientFile.Id == id);

        public IEnumerable<PatientFile> GetAllEager()
        {
            throw new NotImplementedException();
        }
    }
}