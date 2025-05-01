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
    public class FilialConfiguration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.ToTable("Filial");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.RazaoSocial)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.InscricaoEstadual)
                   .HasMaxLength(20);

            builder.Property(e => e.InscricaoMunicipal)
                   .HasMaxLength(20);

            builder.Property(e => e.Logo)
                   .HasMaxLength(500);

            builder.Property(e => e.CpfCnpj)
                   .HasMaxLength(18);

            builder.Property(e => e.TelefoneEmpresa)
                   .HasMaxLength(15);

            builder.Property(e => e.TelefoneResponsavel)
                   .HasMaxLength(15);

            builder.Property(e => e.Email)
                   .HasMaxLength(100);

            builder.Property(e => e.Cep)
                   .HasMaxLength(10);

            builder.Property(e => e.Rua)
                   .HasMaxLength(200);

            builder.Property(e => e.Numero)
                   .HasMaxLength(10);

            builder.Property(e => e.Complemento)
                   .HasMaxLength(100);

            builder.Property(e => e.Bairro)
                   .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                   .HasMaxLength(100);

            builder.Property(e => e.Ativo)
                   .HasDefaultValue(true);

            builder.Property(e => e.Removido)
                   .HasDefaultValue(false);

            builder.Property(e => e.DataCadastro)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasIndex(e => e.CpfCnpj)
                   .IsUnique();

            builder.HasOne(f => f.Empresa)
                   .WithMany(e => e.Filiais)
                   .HasForeignKey(f => f.EmpresaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
