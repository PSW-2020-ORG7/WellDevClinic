using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System.Collections.Generic;


namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenovationController : ControllerBase
    {

        private IRenovationController _renovationController;
        private IBusinessDayController _businessDayController;


        public RenovationController(IRenovationController renovationController, IBusinessDayController businessDayController)
        {
            _renovationController = renovationController;
            _businessDayController = businessDayController;

        }
        [HttpPost]
        [Route("save")]

        public Renovation Save([FromBody] Renovation entity)

        {

            return _renovationController.Save(entity);


        }
        [HttpPost]
        [Route("markAsOccupied/{id?}")]
        public void MarkAsOccupied([FromBody] List<Period> period, long id)
        {
            BusinessDay bd = _businessDayController.Get(id);
            _businessDayController.MarkAsOccupied(period, bd);


        }


    }
}
