//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Institute.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GeneralNotification
    {
        public float GenNotificationID { get; set; }
        public Nullable<System.DateTime> GenNotificationDate { get; set; }
        public string GenNotificationName { get; set; }
        public string GenNotificationFile { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<float> InstitutionID { get; set; }
        public Nullable<System.DateTime> CRDate { get; set; }
        public string Remarks { get; set; }
    }
}
