using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Senha)
                .IsRequired();

            builder.Property(u => u.Cpf)
                .HasMaxLength(11);

            builder.Property(u => u.Telefone)
                .HasMaxLength(20);

            builder.Property(u => u.TipoUsuario)
                .IsRequired();

            builder.Property(u => u.Ativo)
                .IsRequired()
                .HasDefaultValue(true); 

            builder.Property(u => u.Removido)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(u => u.DataCadastro)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 

            builder.Property(u => u.UltimoAcesso);

            builder.HasMany(u => u.EmpresasCadastradas)
               .WithOne(e => e.UsuarioResponsavel)
               .HasForeignKey(e => e.UsuarioResponsavelId);

            builder.HasMany(u => u.UsuarioEmpresas)
                   .WithOne(ue => ue.Usuario)
                   .HasForeignKey(ue => ue.UsuarioId);
        }
    }
}
