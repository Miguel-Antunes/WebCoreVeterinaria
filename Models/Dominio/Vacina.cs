using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    [Table("Vacina")]
    public class Vacina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(40, ErrorMessage = "Tamanho da descrição inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Descrição da vacina é obrigatório!")]
        [Display(Name = "Descrição da vacina")]
        public string descricaoVacina { get; set; }


        [StringLength(40, ErrorMessage = "Tamanho do fabricante inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Fabricante da vacina é obrigatório!")]
        [Display(Name = "Fabricante da vacina")]
        public string fabricanteVacina { get; set; }


       
        [Required(ErrorMessage = "Campo Data da Fabricação da vacina é obrigatório!")]
        [Display(Name = "Fabricação da vacina")]
        public DateTime fabricacaoVacina { get; set; }


        
        [Display(Name = "Validade da vacina")]
        public DateTime validadeVacina { get; set; }

        public ICollection<Procedimento> Procedimentos { get; set; }


    }
}
