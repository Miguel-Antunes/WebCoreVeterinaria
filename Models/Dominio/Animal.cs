using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models.Dominio
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(35, ErrorMessage = "Tamanho do nome inválido!", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Nome Proprietário é obrigatório!")]
        [Display(Name = "Nome do Proprietário")]
        public string nomeProp { get; set; }


        [Required(ErrorMessage = "Campo de cpf é obrigatório!")]
        [Display(Name = "CPF do Proprietário")]
        [Range(minimum: 1, maximum: 99999999999, ErrorMessage = "Limite de campo excedido!")]
        public int cpfProp { get; set; }

        [Display(Name = "Nascimento do Proprietário")]
        [Required(ErrorMessage = "Campo de Data de Nascimento é obrigatório!")]
        public DateTime nascimentoProp { get; set; }
        
        [Display(Name = "Nome do Animal")]
        [Required(ErrorMessage = "Campo de nome do Animal é obrigatório!")]
        [StringLength(30, ErrorMessage = "Tamanho do nome inválido!", MinimumLength = 5)]
        public string nomeAnimal { get; set; }


        [Display(Name = "Espécie do Animal")]
        [StringLength(30, ErrorMessage = "Tamanho da espécie inválido!", MinimumLength = 5)]
        public string especieAnimal { get; set; }

        [Display(Name = "Raça do Animal")]
        [StringLength(30, ErrorMessage = "Tamanho da raça inválido!", MinimumLength = 5)]
        public string racaAnimal { get; set; }

        [Display(Name = "Peso do Animal")]
        [Required(ErrorMessage = "Campo de peso do Animal é obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public float pesoAnimal { get; set; }
        
        public ICollection<Procedimento> Procedimentos { get; set; }

    }
}
