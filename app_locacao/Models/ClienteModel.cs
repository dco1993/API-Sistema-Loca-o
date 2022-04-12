using System;
using System.ComponentModel.DataAnnotations;

namespace api_locacao.Model
{
    public class ClienteModel
    {
        [Display(Name = "Identificação")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite um nome"), MaxLength(200)]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Digite um CPF válido. 11 número!")]
        [StringLength(11, ErrorMessage = "Digite um CPF válido. 11 número!")]
        [MinLength(11, ErrorMessage = "Digite um CPF válido. 11 número!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF aceita apenas números")]
        public string Cpf { get; set; }

        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "É necessário preencher o campo de nascimento!")]
        public DateTime DataNascimento { get; set; }
    }
}
