﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HolidayEntities1 : DbContext
    {
        public HolidayEntities1()
            : base("name=HolidayEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aplications> Aplications { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<WorkerHolidayLeft> WorkerHolidayLeft { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}
