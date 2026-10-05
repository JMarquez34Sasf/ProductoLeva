using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductoLeva.Models;

namespace ProductoLeva.Data;

public partial class ProductoContext : DbContext
{
    public ProductoContext()
    {
    }

    public ProductoContext(DbContextOptions<ProductoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__planes__BECFB996062C9707");

            entity.ToTable("planes");

            entity.Property(e => e.IdPlan).HasColumnName("idPlan");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(100)
                .HasColumnName("frecuencia");
            entity.Property(e => e.Plaan).HasColumnName("plaan");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__07F4A132EA9A1073");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .HasColumnName("detalle");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasColumnName("estado");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A69762DF27");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.IdPlan).HasColumnName("idPlan");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Plaan).HasColumnName("plaan");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("user");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_plan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
