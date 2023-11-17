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
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasOne(p=>p.Cliente).WithMany(p=>p.Pagos).HasForeignKey(p=>p.ClienteId);
            builder.Property(p=>p.Forma_Pago).HasColumnName("Forma_Pago").HasMaxLength(40).IsRequired();
            builder.Property(p=>p.Fecha_Pago).HasColumnName("Fecha_Pago").HasColumnType("datetime").IsRequired();
            builder.Property(p=>p.Total).HasColumnName("Total").HasColumnType("decimal(15,2)").IsRequired();
        }
    }
}