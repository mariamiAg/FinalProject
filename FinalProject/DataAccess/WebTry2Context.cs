using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DataAccess;

public partial class WebTry2Context : DbContext
{
    public WebTry2Context()
    {
    }

    public WebTry2Context(DbContextOptions<WebTry2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerRelationship> CustomerRelationships { get; set; }

    public virtual DbSet<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PhoneType> PhoneTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DbContextOptionsBuilder dbContextOptionsBuilder = optionsBuilder.UseSqlServer("Data Source=ASUS;Initial Catalog=Web_Try2;Integrated Security=True;Application Name=EntityFramework;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Countries_1");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(9)
                .IsFixedLength();

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Cities");

            entity.HasOne(d => d.Country).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Countries");

            entity.HasOne(d => d.Gender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Gender");
        });

        modelBuilder.Entity<CustomerRelationship>(entity =>
        {
            entity.ToTable("CustomerRelationship");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment)
                .HasMaxLength(150)
                .IsFixedLength();

            entity.HasOne(d => d.Endcustomer).WithMany(p => p.CustomerRelationshipEndcustomers)
                .HasForeignKey(d => d.EndcustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRelationship_Customer1");

            entity.HasOne(d => d.Relationship).WithMany(p => p.CustomerRelationships)
                .HasForeignKey(d => d.RelationshipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRelationship_RelationshipTypes");

            entity.HasOne(d => d.StartCustomer).WithMany(p => p.CustomerRelationshipStartCustomers)
                .HasForeignKey(d => d.StartCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerRelationship_Customer");
        });

        modelBuilder.Entity<CustomersPhoneNumber>(entity =>
        {
            entity.Property(e => e.IsMain)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomersPhoneNumbers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomersPhoneNumbers_Customer");

            entity.HasOne(d => d.PhoneType).WithMany(p => p.CustomersPhoneNumbers)
                .HasForeignKey(d => d.PhoneTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomersPhoneNumbers_PhoneTypes");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(7);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders1");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Product");
        });

        modelBuilder.Entity<PhoneType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategories");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<RelationshipType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName).HasMaxLength(30);
            entity.Property(e => e.ContacFullName).HasMaxLength(30);
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.WebSite).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suppliers_Cities");

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suppliers_Countries");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(10);
            entity.Property(e => e.ShortName).HasMaxLength(10);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.DocNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OperationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Product).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Product");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Suppliers");

            entity.HasOne(d => d.Unit).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Units");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
