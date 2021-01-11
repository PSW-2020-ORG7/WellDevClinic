using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDayController : ControllerBase
    {
        private IBusinessDayController _businessDayController;

        public BusinessDayController(IBusinessDayController businessDayController)
        {
            _businessDayController = businessDayController;
        }
        public List<BusinessDay> GetAll()
        {
            return _businessDayController.GetAll().ToList();
        }
    }
}
