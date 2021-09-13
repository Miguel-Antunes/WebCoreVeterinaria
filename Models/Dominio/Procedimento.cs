using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Procedimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        [Display(Name = "Nome do Animal")]
        public Animal nomeAnimal { get; set; }
        public int idAnimal { get; set; }

        
        public Veterinario nomeVeterinario { get; set; }

        [Display(Name = "Nome do veterinário")]
        public int idVeterinario { get; set; }

        
        public Vacina descricaoVacina { get; set; }

        [Display(Name = "Descrição da vacina")]
        public int idVacina { get; set; }


        [Display(Name = "Data do procedimento")]
        [Required(ErrorMessage = "Campo data do procedimento é obrigatório!")]
        public DateTime dataProcedimento { get; set; }

        [Display(Name = "Status Dor")]
        [Required(ErrorMessage = "Campo Status Dor é obrigatório!")]
        [StringLength(40, ErrorMessage = "Tamanho da descrição de Status Dor é inválido!", MinimumLength = 5)]
        public string statusDor { get; set; }

        [Display(Name = "Status Febre")]
        [Required(ErrorMessage = "Campo Status Febre é obrigatório!")]
        [StringLength(40, ErrorMessage = "Tamanho da descrição de Status Febre é inválido!", MinimumLength = 5)]
        public string statusFebre { get; set; }

        [Display(Name = "Status Estado (Tranquilo, Deprimido ou Agressivo)")]
        [Required(ErrorMessage = "Campo Status Estado é obrigatório!")]
        [StringLength(40, ErrorMessage = "Tamanho da descrição de Status Estado é inválido!", MinimumLength = 5)]
        public string statusEstado { get; set; }

        [Display(Name = "Principais Queixas")]
        [Required(ErrorMessage = "Campo Queixa é obrigatório!")]
        [StringLength(250, ErrorMessage = "Tamanho da descrição de Queixa é inválido!", MinimumLength = 15)]
        public string queixa { get; set; }

        [Display(Name = "Descrição do procedimento")]
        [Required(ErrorMessage = "Campo Descrição do procedimento é obrigatório!")]
        [StringLength(1500, ErrorMessage = "Tamanho da descrição do procedimento é inválido!", MinimumLength = 15)]
        public string procedimento { get; set; }

    }
}
