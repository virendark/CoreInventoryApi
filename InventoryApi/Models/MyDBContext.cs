using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryApi.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblColumnType> TblColumnTypes { get; set; }
        public virtual DbSet<TblColumnValue> TblColumnValues { get; set; }
        public virtual DbSet<TblLogin> TblLogins { get; set; }
        public virtual DbSet<TblOutlet> TblOutlets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=InventoryData;user id=sa;password=master");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblColumnType>(entity =>
            {
                entity.Property(e => e.ColumnName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblColumnValue>(entity =>
            {
                entity.Property(e => e.ColumnText).HasMaxLength(40);

                entity.HasOne(d => d.ColumnType)
                    .WithMany(p => p.TblColumnValue)
                    .HasForeignKey(d => d.ColumnTypeId)
                    .HasConstraintName("FK_TblColumnValue_TblColumnType");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.ExpirDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyOn).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(40);

                entity.Property(e => e.UserName).HasMaxLength(40);
            });

            modelBuilder.Entity<TblOutlet>(entity =>
            {
                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.CityName).HasMaxLength(40);

                entity.Property(e => e.CountryName).HasMaxLength(40);

                entity.Property(e => e.DisticName).HasMaxLength(40);

                entity.Property(e => e.OutletName).HasMaxLength(40);

                entity.Property(e => e.StateName).HasMaxLength(40);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TblOutlet)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_TblOutlet_TblLogin");
            });
        }
    }
}
