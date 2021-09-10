using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Vacina
    {
        public int idVacina { get; set; }
        public string descricaoVacina { get; set; }
        public string fabricanteVacina { get; set; }
        public string fabricacaoVacina { get; set; }
        public string validadeVacina { get; set; }


    }
}
