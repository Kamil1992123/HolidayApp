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
    
    public partial class Workers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Workers()
        {
            this.Aplications = new HashSet<Aplications>();
            this.WorkerHolidayLeft1 = new HashSet<WorkerHolidayLeft>();
        }
    
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentID { get; set; }
        public int HolidayID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aplications> Aplications { get; set; }
        public virtual WorkerHolidayLeft WorkerHolidayLeft { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerHolidayLeft> WorkerHolidayLeft1 { get; set; }
    }
}
