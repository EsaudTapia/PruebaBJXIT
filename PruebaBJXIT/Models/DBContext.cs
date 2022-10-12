using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaBJXIT.Models
{
    public class DBContext : DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public DBContext() : base(ConnectionString)
        {

        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos{ get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>()
             .HasMany(e => e.Usuarios)
             .WithRequired(e => e.Rol)
             .HasForeignKey(e => e.IdRol);

            modelBuilder.Entity<Proveedores>()
              .HasMany(e => e.Productos)
              .WithRequired(e => e.Proveedor)
              .HasForeignKey(e => e.IdProvedor);

            modelBuilder.Entity<Clientes>()
              .HasMany(e => e.Pedidos)
              .WithRequired(e => e.Cliente)
              .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Usuarios>()
              .HasMany(e => e.Pedidos)
              .WithRequired(e => e.Usuario)
              .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Pedidos>()
              .HasMany(e => e.PedidoDetalle)
              .WithRequired(e => e.Pedido)
              .HasForeignKey(e => e.IdPedido);


            modelBuilder.Entity<Productos>()
              .HasMany(e => e.PedidoDetalle)
              .WithRequired(e => e.Producto)
              .HasForeignKey(e => e.IdProducto);



            base.OnModelCreating(modelBuilder);

        }


        }

    }
    
