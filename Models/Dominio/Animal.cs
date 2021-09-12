using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Animal
    {
        public int id { get; set; }
        public string nomeProp { get; set; }
        public int cpfProp { get; set; }
        public string nascimentoProp { get; set; }
        public string nomeAnimal { get; set; }
        public string especieAnimal { get; set; }
        public string racaAnimal { get; set; }
        public int pesoAnimal { get; set; }
        public ICollection<Procedimento> Procedimentos { get; set; }

    }
}
