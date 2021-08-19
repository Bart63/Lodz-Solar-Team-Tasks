﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public float Timestamp { get; set; }
        public float CurrentVoltage { get; set; }
        public bool Error { get; set; }
    }
}
