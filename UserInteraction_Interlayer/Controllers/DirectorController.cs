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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorAppService _directorAppService;

        public DirectorController(IDirectorAppService directorAppService)
        {
            _directorAppService = directorAppService;
        }

        [HttpGet]
        public List<Director> GetAll()
        {
            return _directorAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Director GetLazy(long id)
        {
            return _directorAppService.Get(id);
        }

        [HttpGet]
        [Route("eager/{id?}")]
        public Director GetEager(long id)
        {
            return _directorAppService.GetEager(id);
        }

        [HttpPut]
        public void Edit(Director director)
        {
            _directorAppService.Edit(director);
        }
    }
}