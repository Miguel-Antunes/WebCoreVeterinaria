using ClinicaVeterinaria.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Mapeamento
{
    public class VacinaMap : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();


            builder.Property(p => p.descricaoVacina).HasMaxLength(40).IsRequired();

            builder.Property(p => p.fabricanteVacina).HasMaxLength(40).IsRequired();

            builder.Property(p => p.fabricacaoVacina).IsRequired();
            builder.Property(p => p.validadeVacina).IsRequired();

            builder.HasMany(p => p.Procedimentos).WithOne(p => p.descricaoVacina).HasForeignKey(p => p.idVacina).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Vacina");
        }
    }
}
