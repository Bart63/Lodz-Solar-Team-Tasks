using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class MockRepo : IRepo
    {
        public IEnumerable<Measurement> GetMeasurements()
        {
            return new List<Measurement>
            {
                new Measurement {Id=0, CurrentVoltage=0.0f, Timestamp=0, Error=false},
                new Measurement {Id=1, CurrentVoltage=4.3f, Timestamp=1.1f, Error=false},
                new Measurement {Id=2, CurrentVoltage=5.0f, Timestamp=2.0f, Error=false},
                new Measurement {Id=3, CurrentVoltage=4.8f, Timestamp=3.3f, Error=false},
                new Measurement {Id=4, CurrentVoltage=6.3f, Timestamp=3.9f, Error=true},
                new Measurement {Id=5, CurrentVoltage=5.1f, Timestamp=5.1f, Error=false}
            };
        }
    }
}
