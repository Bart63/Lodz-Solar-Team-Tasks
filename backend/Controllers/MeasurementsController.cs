using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    //api/measurments
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IRepo _repo;

        public MeasurementsController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Measurement>> GetAllMeasurements()
        {
            var items = _repo.GetMeasurements();
            return Ok(items);
        }
    }
}
