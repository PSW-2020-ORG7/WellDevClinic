using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class OperationRepository : IOperationRepository
   {
        private readonly IRoomRepository _roomRepository;
        private readonly IDoctorRepository _doctorRepository;
       // private readonly IPatientRepository _patientRepository;
        private readonly MyDbContext myDbContext;

        public OperationRepository(IRoomRepository roomRepository, IDoctorRepository doctorRepository, MyDbContext context)
        {
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
           // _patientRepository = patientRepository;
            myDbContext = context;
        }

        /*public OperationRepository(ICSVStream<Operation> stream, ISequencer<long> sequencer, IRoomRepository roomRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
  : base(stream, sequencer)
        {
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public void Delete(Operation entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Operation entity)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
            => myDbContext.Operation.FirstOrDefault(operation => operation.Id == id);

        public IEnumerable<Operation> GetEager()
        {
            List<Operation> result = new List<Operation>();
            myDbContext.Operation.ToList().ForEach(operation => result.Add(operation));
            return result;
        }

        public IEnumerable<Operation> GetAllEager()
        {
            List<Operation> operations = new List<Operation>();
            foreach (Operation operation in GetEager().ToList())
            {
                operations.Add(GetEager(operation.GetId()));
            }
            return operations;
        }

        public Operation GetEager(long id)
        {
            Operation operation = Get(id);
            operation.Room = _roomRepository.GetEager(operation.Room.GetId());
            operation.Doctor = _doctorRepository.GetEager(operation.Doctor.GetId());
           // operation.Patient = _patientRepository.Get(operation.Patient.GetId());
            return operation;
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            List<Operation> operations = this.GetAllEager().ToList();
            List<Operation> retVal = new List<Operation>();
            foreach(Operation operation in operations)
            {
                if (operation.Doctor.Id == doctor.Id) {
                    retVal.Add(operation);
                }
            }
            return retVal;
        }

        public Operation Save(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}