using EvlaSmartSense.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvlaSmartSense.Web.Models
{
    public class Kalitim
    {
        public SmartSenseEntities1 Dbc { get; set; }
        public Kalitim()
        {
            Dbc = new SmartSenseEntities1();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~Kalitim()
        {
            Dispose();
        }
    }
}