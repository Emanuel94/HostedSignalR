using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HostedSignalR.Models;

public partial class AccountownerContext : DbContext
{
    public AccountownerContext()
    {
    }

    public AccountownerContext(DbContextOptions<AccountownerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    public virtual DbSet<UserAuth> UserAuths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=accountowner;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__account__349DA5A6763B3EE6");

            entity.ToTable("account");

            entity.Property(e => e.AccountId).ValueGeneratedNever();
            entity.Property(e => e.AccountType)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("date");

            entity.HasOne(d => d.Owner).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Account_Owner_idx");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__owner__819385B85BC31454");

            entity.ToTable("owner");

            entity.Property(e => e.OwnerId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Population>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__populati__3214EC078F34F9AD");

            entity.ToTable("population");

            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<UserAuth>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__userAuth__CB9A1CFF4A8345E6");

            entity.ToTable("userAuth");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.DateModified).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
