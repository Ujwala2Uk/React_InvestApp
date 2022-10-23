using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace React_InvestApp.Models
{
    public partial class react_investContext : DbContext
    {
        public react_investContext()
        {
        }

        public react_investContext(DbContextOptions<react_investContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReactApp> ReactApps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//               optionsBuilder.UseSqlServer("Server=ELW5143\\SQLEXPRESS;Database=react_invest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReactApp>(entity =>
            {
                entity.ToTable("react_app");

                entity.Property(e => e.Edescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EDescription");

                entity.Property(e => e.Ename)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
