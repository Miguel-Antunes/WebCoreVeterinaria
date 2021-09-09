using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Procedimento
    {
        public int idProcedimento { get; set; }
        public Animal nomeAnimal { get; set; }
        public Veterinario nomeVeterinario { get; set; }
        public Vacina descricaoVacina { get; set; }
        public string dataProcedimento { get; set; }
        public string statusDor { get; set; }
        public string statusFebre { get; set; }
        public string statusEstado { get; set; }
        public string queixa { get; set; }
        public string procedimento { get; set; }

    }
}
