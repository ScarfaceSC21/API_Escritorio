using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class DbA9ed7aPaqueteriaContext : DbContext
{
    public DbA9ed7aPaqueteriaContext()
    {
    }

    public DbA9ed7aPaqueteriaContext(DbContextOptions<DbA9ed7aPaqueteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.Iidpaquete).HasName("PK__Paquete__DE6DFC65FAF26CF6");

            entity.ToTable("Paquete");

            entity.Property(e => e.Iidpaquete).HasColumnName("IIDPAQUETE");
            entity.Property(e => e.Cajon).HasColumnName("CAJON");
            entity.Property(e => e.Fechaingreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAINGRESO");
            entity.Property(e => e.Fechasalida)
                .HasColumnType("datetime")
                .HasColumnName("FECHASALIDA");
            entity.Property(e => e.Firma)
                .IsUnicode(false)
                .HasColumnName("FIRMA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TIPO");
            entity.Property(e => e.Tracking)
                .IsUnicode(false)
                .HasColumnName("TRACKING");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
