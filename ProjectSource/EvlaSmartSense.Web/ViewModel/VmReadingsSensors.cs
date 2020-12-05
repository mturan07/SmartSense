using EvlaSmartSense.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.ViewModel
{
    public class VmReadingsSensors
    {
        public List<SelectListItem> Sensors { get; set; }
        public List<readings> Readings { get; set; }
    }
}