using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.Property(p=>p.Fecha_Entrega).HasColumnName("Fecha_Entrega").HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Fecha_Esperada).HasColumnName("Fecha_Esperada").HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Fecha_Pedido).HasColumnName("Fecha_Pedido").HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Estado).HasColumnName("Estado").HasMaxLength(15).HasDefaultValue(null);
            builder.Property(p=>p.Comentarios).HasColumnName("Comentarios").HasMaxLength(255).IsRequired();
            builder.HasOne(p=>p.Cliente).WithMany(p=>p.Pedidos).HasForeignKey(p=>p.ClienteId);
        }
    }
}