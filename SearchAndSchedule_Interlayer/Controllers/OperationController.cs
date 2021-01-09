using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;

namespace SearchAndSchedule_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationAppService _operationAppService;

        public OperationController(IOperationAppService operationAppService)
        {
            _operationAppService = operationAppService;
        }


        [HttpPost]
        public Operation Save(Operation operation)
        {
            return _operationAppService.Save(operation);
        }

        [HttpGet]
        public List<Operation> GetAll()
        {
            return _operationAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Operation Get(long id)
        {
            return _operationAppService.Get(id);
        }

        [HttpPut]
        [Route("Delete")]
        public void Delete(Operation operation)
        {
            _operationAppService.Delete(operation);
        }


        [HttpPut]
        [Route("Edit")]
        public void Edit(Operation operation)
        {
            _operationAppService.Edit(operation);
        }

        [HttpGet]
        [Route("GetOperationsByDoctor")]
        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            return _operationAppService.GetOperationsByDoctor(doctor);
        }
    }
}