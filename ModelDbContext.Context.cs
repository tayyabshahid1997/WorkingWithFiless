﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkingWithFiles
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ModelDb : DbContext
    {
        public ModelDb()
            : base("name=ModelDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblFile> tblFiles { get; set; }
    
        public virtual int sp_AddFiles(string fileN, string filePath)
        {
            var fileNParameter = fileN != null ?
                new ObjectParameter("FileN", fileN) :
                new ObjectParameter("FileN", typeof(string));
    
            var filePathParameter = filePath != null ?
                new ObjectParameter("FilePath", filePath) :
                new ObjectParameter("FilePath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AddFiles", fileNParameter, filePathParameter);
        }
    }
}
