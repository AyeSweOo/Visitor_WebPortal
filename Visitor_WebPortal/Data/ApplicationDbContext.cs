using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Visitor_WebPortal.Models;

namespace Visitor_WebPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
         : base(options)
        {
            Configuration = configuration;
        }
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<VisitType> VisitType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitType>(entity =>
            {
                entity.Property(e => e.VisitTypeName).HasMaxLength(100);
            });
            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.CompanyName).HasMaxLength(100);
                entity.Property(e => e.Designation).HasMaxLength(100);
                entity.Property(e => e.MobilePhone).HasMaxLength(50);
                entity.Property(e => e.NRIC).HasMaxLength(50);
                entity.HasOne(d => d.VisitType)
                .WithMany(p => p.Visitor)
                .HasForeignKey(d => d.VisitTypeId)
                .HasConstraintName("FK_Visitor_VisitType");

            });
            base.OnModelCreating(modelBuilder);
        }
      }
}
