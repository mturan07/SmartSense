//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvlaSmartSense.Web.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class readings
    {
        public int ID { get; set; }
        public Nullable<double> AIR_HUMIDITY { get; set; }
        public Nullable<double> AIR_TEMPERATURE { get; set; }
        public Nullable<System.DateTime> RECORDTIME { get; set; }
        public string DEVICEID { get; set; }
    }
}
