using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class OperationAppService : IOperationAppService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationAppService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public void Delete(Operation entity)
        {
            _operationRepository.Delete(entity);
        }

        public void Edit(Operation entity)
        {
            _operationRepository.Edit(entity);
        }

        public Operation Get(long id)
        {
            return _operationRepository.Get(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operationRepository.GetAll();
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            return _operationRepository.GetOperationsByDoctor(doctor);
        }

        public List<Operation> GetOperationsByRoomAndPeriod(Room room, Period period)
        {
            return _operationRepository.GetOperationsByRoomAndPeriod(room, period);
        }

        public Operation Save(Operation entity)
        {
            return _operationRepository.Save(entity);
        }
    }
}
