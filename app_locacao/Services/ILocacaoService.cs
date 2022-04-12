using api_locacao.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public interface ILocacaoService
    {
        Task<IList<LocacaoModel>> GetLocacoes();
        Task<LocacaoModel> GetLocacaoId(int id);
        Task CreateLocacao(LocacaoModel locacao);
        Task UpdateLocacao(LocacaoModel locacao);
        Task DeleteLocacao(int id);
    }
}
