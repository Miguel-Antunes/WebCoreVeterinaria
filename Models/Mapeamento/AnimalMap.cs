using ClinicaVeterinaria.Models.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Mapeamento
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();


            builder.Property(p => p.nomeProp).HasMaxLength(35).IsRequired();
            
            builder.HasIndex(p => p.cpfProp).IsUnique();
            builder.Property(p => p.cpfProp).HasColumnType("Int").IsRequired();
          
            builder.Property(p => p.nascimentoProp).IsRequired();



            builder.Property(p => p.nomeAnimal).HasMaxLength(30).IsRequired();
            
            builder.Property(p => p.especieAnimal).HasMaxLength(30);
            builder.Property(p => p.racaAnimal).HasMaxLength(30);

            builder.Property(p => p.pesoAnimal).HasColumnType("float").IsRequired();

            builder.HasMany(p => p.Procedimentos).WithOne(p => p.nomeAnimal).HasForeignKey(p => p.idAnimal).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Animal");
        }
    }
}
