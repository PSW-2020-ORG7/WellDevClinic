using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretaryController : ControllerBase
    {
        private readonly ISecretaryAppService _secretaryAppService;

        public SecretaryController(ISecretaryAppService secretaryAppService)
        {
            _secretaryAppService = secretaryAppService;
        }

        [HttpGet]
        public List<Secretary> GetAll()
        {
            return _secretaryAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Secretary GetLazy(long id)
        {
            return _secretaryAppService.Get(id);
        }

        [HttpGet]
        [Route("eager/{id?}")]
        public Secretary GetEager(long id)
        {
            return _secretaryAppService.GetEager(id);
        }

        [HttpPut]
        public void Edit(Secretary secretary)
        {
            _secretaryAppService.Edit(secretary);
        }

    }
}