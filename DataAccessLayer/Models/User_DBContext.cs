using System;
using System.Collections.Generic;
using GlobalEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Models
{
    public partial class User_DBContext : DbContext
    {
        public User_DBContext()
        {
        }

        public User_DBContext(DbContextOptions<User_DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FirstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastName");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    //.HasConversion<DateOnlyConverter>()
                    .HasColumnName("CreatedDate");

                entity.Property(e => e.DOB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Gender");

                entity.Property(e => e.Skills)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Skills");

                entity.Property(e => e.Subscribe)
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnName("Subscribe");

                entity.Property(e => e.Year)
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnName("Year");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
    //public class DateOnlyConverter : ValueConverter<DateOnly>
    //{
    //    public DateOnlyConverter() : base(
    //        d => DateOnly.FromDateTime(d))
    //        { }
    //}


