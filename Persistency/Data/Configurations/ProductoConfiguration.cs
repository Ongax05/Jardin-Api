using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(70).IsRequired();
            builder.HasOne(p=>p.Gama_Producto).WithMany(p=>p.Productos).HasForeignKey(p=>p.Gama_ProductoId);
            builder.Property(p=>p.Dimensiones).HasColumnName("Dimensiones").HasMaxLength(25).HasDefaultValue(null);
            builder.Property(p=>p.Proveedor).HasColumnName("Proveedor").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Descripcion).HasColumnName("Descripcion").HasColumnType("longtext").HasDefaultValue(null);
            builder.Property(p=>p.Cantidad_Stock).HasColumnName("Cantidad_Stock").HasColumnType("smallint").IsRequired();
            builder.Property(p=>p.Precio_Venta).HasColumnName("Precio_Venta").HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(p=>p.Precio_Proveedor).HasColumnName("Precio_Proveedor").HasColumnType("decimal(15,2)").IsRequired();
        }
    }
}