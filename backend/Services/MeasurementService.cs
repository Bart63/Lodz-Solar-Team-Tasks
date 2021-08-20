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
    }
}
