using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvlaSmartSense.Web.Models
{
    public class SensorReadings
    {
        public string DeviceID { get; set; }
        public DateTime ReadingDate { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string State { get; set; }
    }
}