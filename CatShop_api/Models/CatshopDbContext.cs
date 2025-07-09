using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatShop_api.Models;

public partial class CatshopDbContext : DbContext
{
    public CatshopDbContext()
    {
    }

    public CatshopDbContext(DbContextOptions<CatshopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Login> Login { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Cat> Cats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B2578D6CFF84");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Createby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createby");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modifiedby");
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Loginid).HasName("PK__Login__4DD9246092C5800C");

            entity.ToTable("Login");

            entity.Property(e => e.Loginid).ValueGeneratedNever();
            entity.Property(e => e.LoginDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Users).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__Login__Userid__49C3F6B7");
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.Breedid).HasName("PK__breeds__9B2F1FB99E32EB70");

            entity.ToTable("breeds");

            entity.Property(e => e.Breedid)
                .ValueGeneratedNever()
                .HasColumnName("breedid");
            entity.Property(e => e.Breedname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("breedname");
        });

        modelBuilder.Entity<Cat>(entity =>
        {
            entity.HasKey(e => e.Catid).HasName("PK__cats__17B9D93E193E809E");

            entity.ToTable("cats");

            entity.Property(e => e.Catid)
                .ValueGeneratedNever()
                .HasColumnName("catid");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Breedid).HasColumnName("breedid");
            entity.Property(e => e.CatName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("catName");
            entity.Property(e => e.CatStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Catdetails)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("catdetails");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("idnumber");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagePath");
            entity.Property(e => e.Images)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("images");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("size");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
