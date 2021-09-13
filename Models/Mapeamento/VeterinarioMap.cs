using ClinicaVeterinaria.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Mapeamento
{
    public class VeterinarioMap : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();


            builder.Property(p => p.nomeVeterinario).HasMaxLength(40).IsRequired();

            builder.HasIndex(p => p.cpfVeterinario).IsUnique();
            builder.Property(p => p.cpfVeterinario).HasColumnType("int").IsRequired();

            builder.Property(p => p.nascimentoVeterinario).IsRequired();

            builder.Property(p => p.telefoneVeterinario).HasColumnType("int").IsRequired();

            builder.Property(p => p.enderecoVeterinario).HasMaxLength(60);
           
            builder.Property(p => p.cidadeVeterinario).HasMaxLength(40).IsRequired();

            builder.Property(p => p.ufVeterinario).HasMaxLength(40).IsRequired();

            builder.HasMany(p => p.Procedimentos).WithOne(p => p.nomeVeterinario).HasForeignKey(p => p.idVeterinario).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Veterinario");
        }
    }
}
