using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=northwind_db;Username=postgres;Password=projectX");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(128)
                    .HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(60)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerCity)
                    .HasMaxLength(15)
                    .HasColumnName("customer_city");

                entity.Property(e => e.CustomerContactName)
                    .HasMaxLength(30)
                    .HasColumnName("customer_contact_name");

                entity.Property(e => e.CustomerContactTitle)
                    .HasMaxLength(30)
                    .HasColumnName("customer_contact_title");

                entity.Property(e => e.CustomerCountry)
                    .HasMaxLength(15)
                    .HasColumnName("customer_country");

                entity.Property(e => e.CustomerFax)
                    .HasMaxLength(24)
                    .HasColumnName("customer_fax");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(24)
                    .HasColumnName("customer_phone");

                entity.Property(e => e.CustomerPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("customer_postal_code");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("fk_customers_regions");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.EmployeeEmail, "employee_email_unique")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(128)
                    .HasColumnName("employee_id");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(60)
                    .HasColumnName("employee_address");

                entity.Property(e => e.EmployeeBirthDate)
                    .HasColumnType("date")
                    .HasColumnName("employee_birth_date");

                entity.Property(e => e.EmployeeCity)
                    .HasMaxLength(15)
                    .HasColumnName("employee_city");

                entity.Property(e => e.EmployeeCountry)
                    .HasMaxLength(15)
                    .HasColumnName("employee_country");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("employee_email");

                entity.Property(e => e.EmployeeExtension)
                    .HasMaxLength(4)
                    .HasColumnName("employee_extension");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("employee_first_name");

                entity.Property(e => e.EmployeeHireDate)
                    .HasColumnType("date")
                    .HasColumnName("employee_hire_date");

                entity.Property(e => e.EmployeeHomePhone)
                    .HasMaxLength(24)
                    .HasColumnName("employee_home_phone");

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("employee_last_name");

                entity.Property(e => e.EmployeeNotes).HasColumnName("employee_notes");

                entity.Property(e => e.EmployeePhoto).HasColumnName("employee_photo");

                entity.Property(e => e.EmployeePhotoPath)
                    .HasMaxLength(255)
                    .HasColumnName("employee_photo_path");

                entity.Property(e => e.EmployeePostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("employee_postal_code");

                entity.Property(e => e.EmployeeSupervisorId)
                    .HasMaxLength(128)
                    .HasColumnName("employee_supervisor_id");

                entity.Property(e => e.EmployeeTitle)
                    .HasMaxLength(30)
                    .HasColumnName("employee_title");

                entity.Property(e => e.EmployeeTitleOfCourtesy)
                    .HasMaxLength(25)
                    .HasColumnName("employee_title_of_courtesy");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.HasOne(d => d.EmployeeSupervisor)
                    .WithMany(p => p.InverseEmployeeSupervisor)
                    .HasForeignKey(d => d.EmployeeSupervisorId)
                    .HasConstraintName("fk_employees_employees");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("fk_employees_regions");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("employee_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderFreight).HasColumnName("order_freight");

                entity.Property(e => e.OrderRequiredDate)
                    .HasColumnType("date")
                    .HasColumnName("order_required_date");

                entity.Property(e => e.OrderShipAddress)
                    .HasMaxLength(60)
                    .HasColumnName("order_ship_address");

                entity.Property(e => e.OrderShipCity)
                    .HasMaxLength(15)
                    .HasColumnName("order_ship_city");

                entity.Property(e => e.OrderShipCountry)
                    .HasMaxLength(15)
                    .HasColumnName("order_ship_country");

                entity.Property(e => e.OrderShipName)
                    .HasMaxLength(40)
                    .HasColumnName("order_ship_name");

                entity.Property(e => e.OrderShipPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("order_ship_postal_code");

                entity.Property(e => e.OrderShipRegionId).HasColumnName("order_ship_region_id");

                entity.Property(e => e.OrderShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("order_shipped_date");

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orders_employees");

                entity.HasOne(d => d.OrderShipRegion)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderShipRegionId)
                    .HasConstraintName("fk_orders_regions");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("fk_orders_shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.OrderDiscount).HasColumnName("order_discount");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

                entity.Property(e => e.OrderUnitPrice).HasColumnName("order_unit_price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductDiscontinued).HasColumnName("product_discontinued");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductQuantityPerUnit)
                    .HasMaxLength(20)
                    .HasColumnName("product_quantity_per_unit");

                entity.Property(e => e.ProductReorderLevel).HasColumnName("product_reorder_level");

                entity.Property(e => e.ProductUnitPrice).HasColumnName("product_unit_price");

                entity.Property(e => e.ProductUnitsInStock).HasColumnName("product_units_in_stock");

                entity.Property(e => e.ProductUnitsOnOrder).HasColumnName("product_units_on_order");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("fk_products_product_categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_products_suppliers");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_categories");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductCategoryDescription).HasColumnName("product_category_description");

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("product_category_name");

                entity.Property(e => e.ProductCategoryPicture).HasColumnName("product_category_picture");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("regions");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.RegionDescription)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("region_description");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("shippers");

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.Property(e => e.ShipperName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("shipper_name");

                entity.Property(e => e.ShipperPhone)
                    .HasMaxLength(24)
                    .HasColumnName("shipper_phone");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.SupplierAddress)
                    .HasMaxLength(60)
                    .HasColumnName("supplier_address");

                entity.Property(e => e.SupplierCity)
                    .HasMaxLength(15)
                    .HasColumnName("supplier_city");

                entity.Property(e => e.SupplierContactName)
                    .HasMaxLength(30)
                    .HasColumnName("supplier_contact_name");

                entity.Property(e => e.SupplierContactTitle)
                    .HasMaxLength(30)
                    .HasColumnName("supplier_contact_title");

                entity.Property(e => e.SupplierCountry)
                    .HasMaxLength(15)
                    .HasColumnName("supplier_country");

                entity.Property(e => e.SupplierFax)
                    .HasMaxLength(24)
                    .HasColumnName("supplier_fax");

                entity.Property(e => e.SupplierHomepage).HasColumnName("supplier_homepage");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("supplier_name");

                entity.Property(e => e.SupplierPhone)
                    .HasMaxLength(24)
                    .HasColumnName("supplier_phone");

                entity.Property(e => e.SupplierPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("supplier_postal_code");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("fk_suppliers_regions");
            });

            modelBuilder.HasSequence<short>("categories_category_id_seq");

            modelBuilder.HasSequence<short>("shippers_shipper_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
