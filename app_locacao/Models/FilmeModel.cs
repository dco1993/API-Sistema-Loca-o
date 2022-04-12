using System.ComponentModel.DataAnnotations;

namespace api_locacao.Model
{
    public class FilmeModel
    {
        [Display(Name = "Identificação")]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Digite um título"), MaxLength(200)]
        public string Titulo { get; set; }

        [Display(Name = "Classificação Indicativa")]
        [Required(ErrorMessage = "Digite uma idade válida!")]
        [Range(1, 99, ErrorMessage = "Apenas números de 1 até 99 no campo idade!")]
        public int ClassificacaoIndicativa { get; set; }

        [Display(Name = "Lançamento?")]
        public bool Lancamento { get; set; }
    }
}
