using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(p=>p.Nombre_Cliente).HasColumnName("Nombre_Cliente").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Nombre_Contacto).HasColumnName("Nombre_Contacto").HasMaxLength(30).HasDefaultValue(null);
            builder.Property(p=>p.Apellido_Contacto).HasColumnName("Apellido_Contacto").HasMaxLength(30).HasDefaultValue(null);
            builder.Property(p=>p.Telefono).HasColumnName("Telefono").HasMaxLength(15).IsRequired();
            builder.Property(p=>p.Fax).HasColumnName("Fax").HasMaxLength(15).IsRequired();
            builder.Property(p=>p.Linea_Direccion1).HasColumnName("Linea_Direccion1").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Linea_Direccion2).HasColumnName("Linea_Direccion2").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Ciudad).HasColumnName("Ciudad").HasMaxLength(50).IsRequired();
            builder.Property(p=>p.Region).HasColumnName("Region").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Pais).HasColumnName("Pais").HasMaxLength(50).HasDefaultValue(null);
            builder.Property(p=>p.Codigo_Postal).HasColumnName("Codigo_Postal").HasMaxLength(10).HasDefaultValue(null);
            builder.HasOne(p=>p.Empleado).WithMany(p=>p.Clientes).HasForeignKey(p=>p.EmpleadoId).IsRequired(false);
            builder.Property(p=>p.Limite_Credito).HasColumnName("Limite_Credito").HasColumnType("decimal(15,2)").HasDefaultValue(null);
        }
    }
}