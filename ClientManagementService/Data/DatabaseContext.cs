using ClientManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchStaff> BranchStaffs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.BranchName).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.ManagerName).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Contact).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
            });

            modelBuilder.Entity<BranchStaff>(entity =>
            {
                entity.ToTable("BranchStaff");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FirstName).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.Gender).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.UserId).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Contact).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.BranchId).IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CompanyName).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.ContactPerson).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.Contact).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.BranchId).IsUnicode(false);
                entity.Property(e => e.CurrencyId).IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Code).HasMaxLength(3).IsUnicode(false);
                entity.Property(e => e.Symbol).HasMaxLength(20).IsUnicode(true);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
