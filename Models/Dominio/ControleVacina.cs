using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class ControleVacina
    {
        public Vacina idVacina { get; set; }
        public Procedimento idProcedimento { get; set; }
        public string dataVacinacao { get; set; }

    }
}
