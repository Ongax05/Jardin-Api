using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Apellido1).HasColumnName("Apellido1").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Apellido2).HasColumnName("Apellido2").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Extension).HasColumnName("Extension").HasMaxLength(10).IsRequired();
            builder.Property(p=>p.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.HasOne(p=>p.Oficina).WithMany(p=>p.Empleados).HasForeignKey(p=>p.OficinaId);
            builder.HasOne(p=>p.Jefe).WithMany(p=>p.Empleados).HasForeignKey(p=>p.Codigo_Jefe);
            builder.Property(p=>p.Puesto).HasColumnName("Puesto").HasMaxLength(50).HasDefaultValue(null);
            
        }
    }
}