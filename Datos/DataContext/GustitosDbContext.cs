using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Datos.DataContext;

public partial class GustitosDbContext : DbContext
{
    public GustitosDbContext()
    {
    }

    public GustitosDbContext(DbContextOptions<GustitosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("Id_Categoria");
            entity.Property(e => e.Categoria1)
                .HasMaxLength(50)
                .HasColumnName("Categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("Id_Cliente");
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.IdOrden);

            entity.Property(e => e.IdOrden)
                .ValueGeneratedNever()
                .HasColumnName("Id_Orden");
            entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK_Ordenes_Pedidos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Ordenes_Productos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.Property(e => e.IdPedido)
                .ValueGeneratedNever()
                .HasColumnName("Id_Pedido");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Hora");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedidos_Clientes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("Id_Producto");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categorias");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
