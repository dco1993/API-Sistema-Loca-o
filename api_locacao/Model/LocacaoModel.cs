using System;

namespace api_locacao.Model
{
    public class LocacaoModel
    {
        public int Id { get; set; }

        public int Id_Cliente { get; set; }
        public ClienteModel Cliente { get; set; }

        public int Id_Filme { get; set; }
        public FilmeModel Filme { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
