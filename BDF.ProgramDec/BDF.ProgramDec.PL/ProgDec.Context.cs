﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDF.ProgramDec.PL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProgDecEntities : DbContext
    {
        public ProgDecEntities()
            : base("name=ProgDecEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDegreeType> tblDegreeTypes { get; set; }
        public virtual DbSet<tblProgram> tblPrograms { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblProgDec> tblProgDecs { get; set; }
    }
}