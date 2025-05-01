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
    public class UsuarioFilialConfiguration : IEntityTypeConfiguration<UsuarioFilial>
    {
        public void Configure(EntityTypeBuilder<UsuarioFilial> builder)
        {
            builder.ToTable("UsuarioFilial");

            builder.HasKey(uf => uf.Id);

            builder.Property(uf => uf.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(uf => uf.Usuario)
                   .WithMany(u => u.UsuarioFiliais)
                   .HasForeignKey(uf => uf.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uf => uf.Filial)
                   .WithMany(f => f.UsuarioFiliais)
                   .HasForeignKey(uf => uf.FilialId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(uf => uf.DataCadastro)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
