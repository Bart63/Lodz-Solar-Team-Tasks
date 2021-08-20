using Backend.Models;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class MongoRepo : IRepo
    {
        private readonly MeasurementService _ms;

        public MongoRepo(MeasurementService ms)
        {
            _ms = ms;
        }

        public void CreateMeasurement(Measurement measurement)
        {
            _ms.Create(measurement);
        }

        public Measurement GetMeasurement(string id)
        {
            return _ms.Get(id);
        }

        public IEnumerable<Measurement> GetMeasurements()
        {
            return _ms.GetAll();
        }

        public Measurement GetRecent()
        {
            return _ms.GetRecent();
        }

        public Measurement Predict(double time)
        {
            return _ms.Predict(time);
        }
    }
}
