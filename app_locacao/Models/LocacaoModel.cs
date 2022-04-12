using System;
using System.ComponentModel.DataAnnotations;

namespace api_locacao.Model
{
    public class LocacaoModel
    {
        [Display(Name = "Identificação")]
        public int Id { get; set; }

        [Display(Name = "Identificação Cliente")]
        [Required(ErrorMessage = "É necessário escolher o cliente que deseja efetuar a locação!")]
        public int Id_Cliente { get; set; }
        public ClienteModel Cliente { get; set; }

        [Display(Name = "Identificação Filme")]
        [Required(ErrorMessage = "É necessário escolher o filme que será alugado!")]
        public int Id_Filme { get; set; }
        public FilmeModel Filme { get; set; }

        [Display(Name = "Data de Locação")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy H:mm:ss}")]
        [Required(ErrorMessage = "É necessário escolher a data de locação!")]
        public DateTime DataLocacao { get; set; }

        [Display(Name = "Data de Devolução")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy H:mm:ss}")]
        public DateTime DataDevolucao { get; set; }
    }
}
