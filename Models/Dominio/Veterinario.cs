using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Veterinario
    {
        public int id { get; set; }
        public string nomeVeterinario { get; set; }
        public int cpfVeterinario { get; set; }
        public string nascimentoVeterinario { get; set; }
        public int telefoneVeterinario { get; set; }
        public string enderecoVeterinario { get; set; }
        public string cidadeVeterinario { get; set; }
        public string ufVeterinario { get; set; }
        public  ICollection<Procedimento> Procedimentos { get; set; }

    }
}
