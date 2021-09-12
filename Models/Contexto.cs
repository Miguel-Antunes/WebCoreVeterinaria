using ClinicaVeterinaria.Models.Dominio;
using ClinicaVeterinaria.Models.Mapeamento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Animal> Animais { get; set; }
   
    
    
         protected override void OnModelCreating(ModelBuilder builder)
         {
        
            builder.ApplyConfiguration(new AnimalMap());
     
        }
    
    
    }
    
}
