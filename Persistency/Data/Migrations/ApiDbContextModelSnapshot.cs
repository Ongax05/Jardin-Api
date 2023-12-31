﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistency;

#nullable disable

namespace Persistency.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido_Contacto")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Apellido_Contacto");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Ciudad");

                    b.Property<string>("Codigo_Postal")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Codigo_Postal");

                    b.Property<int?>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Fax");

                    b.Property<decimal?>("Limite_Credito")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Limite_Credito");

                    b.Property<string>("Linea_Direccion1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Linea_Direccion1");

                    b.Property<string>("Linea_Direccion2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Linea_Direccion2");

                    b.Property<string>("Nombre_Cliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre_Cliente");

                    b.Property<string>("Nombre_Contacto")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Nombre_Contacto");

                    b.Property<string>("Pais")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Pais");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Region");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Detalle_Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<string>("ProductoId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<short>("Numero_Linea")
                        .HasColumnType("smallint")
                        .HasColumnName("Numero_Linea");

                    b.Property<decimal>("Precio_Unidad")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Precio_Unidad");

                    b.HasKey("PedidoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Detalle_Pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Apellido1");

                    b.Property<string>("Apellido2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Apellido2");

                    b.Property<int?>("Codigo_Jefe")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Extension");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<string>("OficinaId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Puesto")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Puesto");

                    b.HasKey("Id");

                    b.HasIndex("Codigo_Jefe");

                    b.HasIndex("OficinaId");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Gama_Producto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion_HTML")
                        .HasColumnType("longtext")
                        .HasColumnName("Descripcion_HTML");

                    b.Property<string>("Descripcion_Texto")
                        .HasColumnType("longtext")
                        .HasColumnName("Descripcion_Texto");

                    b.Property<string>("Imagen")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Imagen");

                    b.HasKey("Id");

                    b.ToTable("Gama_Producto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Oficina", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ciudad");

                    b.Property<string>("Codigo_Postal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Codigo_Postal");

                    b.Property<string>("Linea_Direccion1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Linea_Direccion1");

                    b.Property<string>("Linea_Direccion2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Linea_Direccion2");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Pais");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Region");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefono");

                    b.HasKey("Id");

                    b.ToTable("Oficina", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Pago")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Pago");

                    b.Property<string>("Forma_Pago")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Forma_Pago");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasAlternateKey("Id", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pago", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Comentarios");

                    b.Property<string>("Estado")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Estado");

                    b.Property<DateTime?>("Fecha_Entrega")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Entrega");

                    b.Property<DateTime>("Fecha_Esperada")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Esperada");

                    b.Property<DateTime>("Fecha_Pedido")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha_Pedido");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<short>("Cantidad_Stock")
                        .HasColumnType("smallint")
                        .HasColumnName("Cantidad_Stock");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext")
                        .HasColumnName("Descripcion");

                    b.Property<string>("Dimensiones")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Dimensiones");

                    b.Property<string>("Gama_ProductoId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("Nombre");

                    b.Property<decimal?>("Precio_Proveedor")
                        .IsRequired()
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Precio_Proveedor");

                    b.Property<decimal>("Precio_Venta")
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("Precio_Venta");

                    b.Property<string>("Proveedor")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Proveedor");

                    b.HasKey("Id");

                    b.HasIndex("Gama_ProductoId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("rolName");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Empleado", "Empleado")
                        .WithMany("Clientes")
                        .HasForeignKey("EmpleadoId");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Domain.Entities.Detalle_Pedido", b =>
                {
                    b.HasOne("Domain.Entities.Pedido", "Pedido")
                        .WithMany("Detalles_Pedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Producto", "Producto")
                        .WithMany("Detalles_Pedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Empleado", "Jefe")
                        .WithMany("Empleados")
                        .HasForeignKey("Codigo_Jefe");

                    b.HasOne("Domain.Entities.Oficina", "Oficina")
                        .WithMany("Empleados")
                        .HasForeignKey("OficinaId");

                    b.Navigation("Jefe");

                    b.Navigation("Oficina");
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pagos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Entities.Gama_Producto", "Gama_Producto")
                        .WithMany("Productos")
                        .HasForeignKey("Gama_ProductoId");

                    b.Navigation("Gama_Producto");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pagos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Gama_Producto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.Oficina", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Detalles_Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("Detalles_Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
