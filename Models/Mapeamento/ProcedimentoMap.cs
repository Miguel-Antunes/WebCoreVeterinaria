using ClinicaVeterinaria.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Mapeamento
{
    public class ProcedimentoMap : IEntityTypeConfiguration<Procedimento>
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();


            builder.Property(p => p.idAnimal).IsRequired();
            builder.Property(p => p.idVeterinario).IsRequired();
            builder.Property(p => p.idVacina).IsRequired();
            builder.Property(p => p.dataProcedimento).IsRequired();
            builder.Property(p => p.statusDor).IsRequired().HasMaxLength(40);
            builder.Property(p => p.statusFebre).IsRequired().HasMaxLength(40);
            builder.Property(p => p.statusEstado).IsRequired().HasMaxLength(40);
            builder.Property(p => p.queixa).IsRequired().HasMaxLength(250);
            builder.Property(p => p.procedimento).IsRequired().HasMaxLength(1500);
            

            builder.HasOne(p => p.nomeAnimal).WithMany(p => p.Procedimentos).HasForeignKey(p => p.idAnimal).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.nomeVeterinario).WithMany(p => p.Procedimentos).HasForeignKey(p => p.idVeterinario).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.descricaoVacina).WithMany(p => p.Procedimentos).HasForeignKey(p => p.idVacina).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Procedimento");
        }
    }
}
