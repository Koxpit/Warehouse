﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Storage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Territory { get; set; }
        public string Address { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
    }
}
