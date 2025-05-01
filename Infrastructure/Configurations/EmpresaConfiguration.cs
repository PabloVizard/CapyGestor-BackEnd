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

            builder.Property(e => e.Ativo)
                   .HasDefaultValue(true);

            builder.Property(e => e.Removido)
                   .HasDefaultValue(false);

            builder.Property(e => e.DataCadastro)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

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
