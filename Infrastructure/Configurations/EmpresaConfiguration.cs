using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

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

            builder.HasOne(e => e.UsuarioResponsavel)
               .WithMany(u => u.EmpresasCadastradas)
               .HasForeignKey(e => e.UsuarioResponsavelId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.UsuarioEmpresas)
                   .WithOne(ue => ue.Empresa)
                   .HasForeignKey(ue => ue.EmpresaId);
        }
    }
}
