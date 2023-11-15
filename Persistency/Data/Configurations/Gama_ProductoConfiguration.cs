using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class Gama_ProductoConfiguration : IEntityTypeConfiguration<Gama_Producto>
    {
        public void Configure(EntityTypeBuilder<Gama_Producto> builder)
        {
            builder.ToTable("Gama_Producto");
            builder.Property(p=>p.Descripcion_Texto).HasColumnName("Descripcion_Texto").HasColumnType("longtext").IsRequired();
            builder.Property(p=>p.Descripcion_HTML).HasColumnName("Descripcion_HTML").HasColumnType("longtext").IsRequired();
            builder.Property(p=>p.Imagen).HasColumnName("Imagen").HasMaxLength(255).IsRequired();
            
        }
    }
}