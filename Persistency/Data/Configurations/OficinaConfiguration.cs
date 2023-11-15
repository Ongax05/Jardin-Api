using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class OficinaConfiguration : IEntityTypeConfiguration<Oficina>
    {
        public void Configure(EntityTypeBuilder<Oficina> builder)
        {
            builder.ToTable("Oficina");
            builder.Property(p=>p.Ciudad).HasColumnName("Ciudad").HasMaxLength(30).IsRequired();
            builder.Property(p=>p.Pais).HasColumnName("Pais").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Region).HasColumnName("Region").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Codigo_Postal).HasColumnName("Codigo_Postal").HasMaxLength(10).IsRequired();
            builder.Property(p=>p.Telefono).HasColumnName("Telefono").HasMaxLength(20).IsRequired();
            builder.Property(p=>p.Linea_Direccion1).HasColumnName("Linea_Direccion1").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Linea_Direccion2).HasColumnName("Linea_Direccion2").HasMaxLength(50).HasDefaultValue(null);
        }
    }
}