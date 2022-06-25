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
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferItem> OfferItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Branch>()
            //    .HasMany(c => c.BranchStaffs)
            //    .WithOne(e => e.Branch);

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.BranchName).HasMaxLength(200).IsUnicode(false).IsRequired();
                entity.Property(e => e.ManagerName).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Contact).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
            });

            modelBuilder.Entity<BranchStaff>(entity =>
            {
                entity.ToTable("BranchStaff");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FirstName).HasMaxLength(150).IsUnicode(false).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.Gender).HasMaxLength(10).IsUnicode(false).IsRequired();
                entity.Property(e => e.UserId).HasMaxLength(50).IsUnicode(false).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(200).IsUnicode(false).IsRequired();
                entity.Property(e => e.Contact).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.BranchId).IsUnicode(false).IsRequired();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CompanyName).HasMaxLength(150).IsUnicode(false).IsRequired();
                entity.Property(e => e.ContactPerson).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.Contact).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(70).IsUnicode(false);
                entity.Property(e => e.Location).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.BranchId).IsUnicode(false).IsRequired();
                entity.Property(e => e.CurrencyId).IsUnicode(false).IsRequired();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Code).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.Symbol).HasMaxLength(20).IsUnicode(true);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasMaxLength(200).IsUnicode(false).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500).IsUnicode(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Code).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(200).IsUnicode(false).IsRequired();
                entity.Property(e => e.ProductCategoryId).IsUnicode(false).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Descripion).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.AvailableQuantity).IsUnicode(false).IsRequired();
                entity.Property(e => e.Duration).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.IsLicenseProduct).IsRequired();
                entity.Property(e => e.LicenseType).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.ProtectionType).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Comment).HasMaxLength(500).IsUnicode(false);
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("ProductPrice");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ProductId).IsUnicode(false).IsRequired();
                entity.Property(e => e.CurrencyId).IsUnicode(false).IsRequired();
                entity.Property(e => e.UnitPrice).IsUnicode(false).HasColumnType("decimal(10,3)").IsRequired();
                entity.Property(e => e.GSTApplicable).IsUnicode(true);
                entity.Property(e => e.IsActive).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.ActivationDate).IsUnicode(false);
                entity.Property(e => e.StopDate).IsUnicode(false);
            });


            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ClientID).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.BranchId).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.CustomerCurrency).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.OfferTotal).IsUnicode(false).HasColumnType("decimal(10,3)").IsRequired();
                entity.Property(e => e.OfferTax).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OfferDiscount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.NetworkSurcharge).IsUnicode(false).HasColumnType("decimal(10,3)");
                entity.Property(e => e.SoftwareMaintenance).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.ManualDiscount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OriginalOfferTotal).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.Comment).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.CreatedBy).HasMaxLength(100).IsUnicode(false);
            });

            modelBuilder.Entity<OfferItem>(entity =>
            {
                entity.ToTable("OfferItem");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.OfferId).IsUnicode(false).IsRequired();
                entity.Property(e => e.ProductId).IsUnicode(false).IsRequired();
                entity.Property(e => e.Quantity).IsUnicode(false).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,3)").IsUnicode(false).IsRequired();
                entity.Property(e => e.IsTaxApplied).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.TaxAmount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.IsDiscountApplied).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OriginalProductCost).HasColumnType("decimal(10,3)").IsUnicode(false).IsRequired();
                entity.Property(e => e.ItemWeight).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Comment).HasMaxLength(500).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ClientID).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.BranchId).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.CustomerCurrency).HasMaxLength(3).IsUnicode(false).IsRequired();
                entity.Property(e => e.OrderTotal).HasColumnType("decimal(10,3)").IsUnicode(false).IsRequired();
                entity.Property(e => e.OrderTax).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OrderDiscount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.NetworkSurcharge).IsUnicode(false).HasColumnType("decimal(10,3)");
                entity.Property(e => e.SoftwareMaintenance).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.ManualDiscount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OriginalOrderTotal).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.Comment).HasMaxLength(500).IsUnicode(false);
                entity.Property(e => e.CreatedBy).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.IsFromOffer).IsUnicode(false).IsRequired();
                entity.Property(e => e.OfferId).IsUnicode(false);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.OrderId).IsUnicode(false).IsRequired();
                entity.Property(e => e.ProductId).IsUnicode(false).IsRequired();
                entity.Property(e => e.Quantity).IsUnicode(false).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,3)").IsUnicode(false).IsRequired();
                entity.Property(e => e.IsTaxApplied).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.TaxAmount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.IsDiscountApplied).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10,3)").IsUnicode(false);
                entity.Property(e => e.OriginalProductCost).HasColumnType("decimal(10,3)").IsUnicode(false).IsRequired();
                entity.Property(e => e.ItemWeight).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Comment).HasMaxLength(500).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
