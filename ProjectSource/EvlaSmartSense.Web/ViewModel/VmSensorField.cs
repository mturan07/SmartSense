using EvlaSmartSense.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.ViewModel
{
    public class VmSensorField
    {
        public List<SelectListItem> AlanListesi { get; set; }
        public sensors Sensors { get; set; }
    }
}