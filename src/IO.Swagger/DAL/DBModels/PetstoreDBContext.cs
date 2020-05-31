using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IO.Swagger.DBModels
{
    public partial class PetstoreDBContext : DbContext
    {
        public PetstoreDBContext()
        {
        }

        public PetstoreDBContext(DbContextOptions<PetstoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetTagMapping> PetTagMapping { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:home-sqlserver.database.windows.net,1433;Database=PetstoreDB;Trusted_Connection=True;User Id=home-admin;Password=Covid19!;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Category__72E12F1BE07B17E6")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Customer__AB6E6164078B2432")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__Customer__6E2DBEDEBDEC29AB")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Customer__B43B145FE6986663")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Customer__F3DBC5721B62B3FF")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(128);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(64);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(64);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(16);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipDate)
                    .HasColumnName("ship_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShippingAddress)
                    .IsRequired()
                    .HasColumnName("shipping_address")
                    .HasMaxLength(250);

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__custome__5FB337D6");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__status___5EBF139D");
            });

            modelBuilder.Entity<InvoiceStatus>(entity =>
            {
                entity.ToTable("Invoice_Status");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Invoice___72E12F1BBC8D8952")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(32);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Pet__category_id__5070F446");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Pet)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK__Pet__invoice_id__68487DD7");
            });

            modelBuilder.Entity<PetTagMapping>(entity =>
            {
                entity.ToTable("Pet_Tag_Mapping");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetTagMapping)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pet_Tag_M__pet_i__66603565");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PetTagMapping)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pet_Tag_M__tag_i__6754599E");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Tag__72E12F1BCA4C4E51")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
