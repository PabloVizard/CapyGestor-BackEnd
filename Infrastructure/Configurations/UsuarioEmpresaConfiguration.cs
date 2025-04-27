using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class UsuarioEmpresaConfiguration : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.ToTable("UsuarioEmpresa");

            builder.HasKey(ue => ue.Id);
            builder.Property(ue => ue.Id).ValueGeneratedOnAdd();

            builder.HasOne(ue => ue.Usuario)
                   .WithMany(u => u.UsuarioEmpresas)
                   .HasForeignKey(ue => ue.UsuarioId);

            builder.HasOne(ue => ue.Empresa)
                   .WithMany(e => e.UsuarioEmpresas)
                   .HasForeignKey(ue => ue.EmpresaId);

            builder.Property(ue => ue.DataCadastro)
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
