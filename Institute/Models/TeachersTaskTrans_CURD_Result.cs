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
    
    public partial class TeachersTaskTrans_CURD_Result
    {
        public float TeacherTranID { get; set; }
        public Nullable<float> BatchTaskID { get; set; }
        public string InOrOut { get; set; }
        public Nullable<float> UserID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Nullable<System.DateTime> TaskDate { get; set; }
        public Nullable<System.TimeSpan> TaskTime { get; set; }
        public Nullable<float> SLNO { get; set; }
        public Nullable<float> InstitutionID { get; set; }
        public Nullable<System.DateTime> CRDate { get; set; }
    }
}
