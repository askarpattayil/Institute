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
    
    public partial class UserLog
    {
        public float LogID { get; set; }
        public string TransCode { get; set; }
        public string TransName { get; set; }
        public Nullable<System.DateTime> TransDate { get; set; }
        public string TranAction { get; set; }
        public Nullable<float> TransUserID { get; set; }
        public Nullable<float> InstitutionID { get; set; }
        public Nullable<System.DateTime> CRDate { get; set; }
    }
}
