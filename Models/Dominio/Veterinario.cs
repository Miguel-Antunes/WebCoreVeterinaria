using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    public class Veterinario
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int id { get; set; }


        [StringLength(40, ErrorMessage = "Tamanho do nome inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Nome do Veterinário é obrigatório!")]
        [Display(Name = "Nome do veterinário")]
        public string nomeVeterinario { get; set; }



        [Required(ErrorMessage = "Campo de cpf é obrigatório!")]
        [Display(Name = "CPF do Veterinário")]
        [Range(minimum: 1, maximum: 99999999999, ErrorMessage = "Limite de campo excedido!")]
        public int cpfVeterinario { get; set; }


        [Display(Name = "Nascimento do Veterinário")]
        [Required(ErrorMessage = "Campo de Data de Nascimento é obrigatório!")]
        public DateTime nascimentoVeterinario { get; set; }


        [Display(Name = "Telefone do veterinário")]
        [Required(ErrorMessage = "Campo de telefone é obrigatório!")]
        [Range(minimum: 1, maximum: 99999999999, ErrorMessage = "Limite de campo excedido!")]
        public int telefoneVeterinario { get; set; }

        [StringLength(60, ErrorMessage = "Tamanho do endereço inválido!", MinimumLength = 5)]
        [Display(Name = "Endereço do veterinário")]
        public string enderecoVeterinario { get; set; }

        [StringLength(40, ErrorMessage = "Tamanho da cidade  inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Cidade do Veterinário é obrigatório!")]
        [Display(Name = "Cidade do veterinário")]
        public string cidadeVeterinario { get; set; }

        [StringLength(40, ErrorMessage = "Tamanho do estado inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Estado do Veterinário é obrigatório!")]
        [Display(Name = "Estado do veterinário")]
        public string ufVeterinario { get; set; }

        public  ICollection<Procedimento> Procedimentos { get; set; }

    }
}
