using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class Detalle_PedidoConfiguration : IEntityTypeConfiguration<Detalle_Pedido>
    {
        public void Configure(EntityTypeBuilder<Detalle_Pedido> builder)
        {
            builder.ToTable("Detalle_Pedido");
            builder.HasOne(p=>p.Pedido).WithMany(p=>p.Detalles_Pedidos).HasForeignKey(p=>p.PedidoId);
            builder.HasOne(p=>p.Producto).WithMany(p=>p.Detalles_Pedidos).HasForeignKey(p=>p.ProductoId);
            builder.Property(p=>p.Cantidad).HasColumnName("Cantidad").HasColumnType("int").IsRequired();
            builder.Property(p=>p.Precio_Unidad).HasColumnName("Precio_Unidad").HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(p=>p.Numero_Linea).HasColumnName("Numero_Linea").HasColumnType("tinyint").IsRequired();
        }
    }
}