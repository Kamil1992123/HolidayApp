//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HolidayApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Aplications
    {

        
        public int AplicationID { get; set; }
        public int WorkerID { get; set; }
        public System.DateTime HolidayStart { get; set; }
        public System.DateTime HolidayStop { get; set; }
        public int DayOffSum { get; set; }
        public int DepartmentID { get; set; }
        public string HolidayType { get; set; }
        public int StatusID { get; set; }
    
        public virtual Workers Workers { get; set; }
        public virtual Departments Departments { get; set; }
        public virtual Status Status { get; set; }
    }
}
