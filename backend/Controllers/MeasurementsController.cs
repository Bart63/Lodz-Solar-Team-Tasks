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
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IRepo _repo;

        public MeasurementsController(IRepo repo)
        {
            _repo = repo;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult <IEnumerable<Measurement>> GetAllMeasurements()
        {
            var items = _repo.GetMeasurements();
            return Ok(items);
        }

        [Route("api/[controller]")]
        [HttpGet("{id:length(24)}", Name = "GetMeasurement")]
        public ActionResult<Measurement> GetMeasurement(string id)
        {
            var item = _repo.GetMeasurement(id);
            if(item==null)
            {
                return NotFound();
            }
            return item;
        }

        [Route("api/recent")]
        [HttpGet]
        public ActionResult <Measurement> GetRecentMeasurement()
        {
            Measurement item = _repo.GetRecent();
            return Ok(item);
        }

        [Route("api/create")]
        [HttpPost]
        public ActionResult<Measurement> CreateMeasurement([FromBody] Measurement measurement)
        {
            _repo.CreateMeasurement(measurement);
            return CreatedAtRoute("GetMeasurement", new { id = measurement.Id.ToString() }, measurement);
        }

        [Route("api/predict")]
        [HttpGet]
        public ActionResult<Measurement> GetRecentMeasurement([FromQuery] double time)
        {
            Measurement item = _repo.Predict(time);
            return Ok(item);
        }
    }
}
