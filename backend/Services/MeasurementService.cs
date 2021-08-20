using Backend.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class MeasurementService
    {
        private readonly IMongoCollection<Measurement> _measurements;

        public MeasurementService(IMeasurementsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _measurements = database.GetCollection<Measurement>(settings.MeasurementsCollectionName);
        }

        public List<Measurement> GetAll() => _measurements.Find(x => true).ToList();
        public Measurement Get(string id) => _measurements.Find(m => m.Id == id).FirstOrDefault();

        public Measurement GetRecent() => _measurements.Find(x => true).SortByDescending(m => m.Timestamp).Limit(1).FirstOrDefault();

        public Measurement Create(Measurement m)
        {
            _measurements.InsertOne(m);
            return m;
        }

        public Measurement Predict(double time)
        {
            double now = GetRecent().Timestamp;
            List<Measurement> measurements = _measurements.Find(x => !x.Error).Limit(10).ToList();
            List<double> timestamps = measurements.Select(i => i.Timestamp).ToList();

            if (measurements.Count<2 || timestamps.GroupBy(t => t).Count() == 1)
            {
                return new Measurement { CurrentVoltage = 0, Timestamp = now + time, Error = true };
            }

            List<double> voltages = measurements.Select(i => i.CurrentVoltage).ToList();

            LinearRegression.Solve(timestamps, voltages, out double intercept, out double slope);

            double requestedTime = (now + time);
            double predictedVoltage = (slope * requestedTime) + intercept;

            return new Measurement { CurrentVoltage = predictedVoltage, Timestamp = requestedTime, Error = false };
        }
    }
}
