using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrandClickr.Models;

public partial class GrandClickrContext : DbContext
{
    public GrandClickrContext()
    {
    }

    public GrandClickrContext(DbContextOptions<GrandClickrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Secret> Secrets { get; set; }

    public virtual DbSet<UserName> UserNames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Secret>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Secrets__UserId__38996AB5");
        });

        modelBuilder.Entity<UserName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserName__3214EC0781C159F1");

            entity.ToTable("UserName");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.UserName1)
                .HasMaxLength(50)
                .HasColumnName("UserName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
