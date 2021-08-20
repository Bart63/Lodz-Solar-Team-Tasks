using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface IRepo
    {
        IEnumerable<Measurement> GetMeasurements();
        Measurement GetMeasurement(string id);
        Measurement GetRecent();
        Measurement Predict(double time);
        void CreateMeasurement(Measurement measurement);
    }
}
