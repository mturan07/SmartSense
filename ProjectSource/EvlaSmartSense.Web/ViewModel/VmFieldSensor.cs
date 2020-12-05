using EvlaSmartSense.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.ViewModel
{
    public class VmFieldSensor
    {
        public List<SelectListItem> SensorListesi { get; set; }
        public fields Fields { get; set; }
    }
}