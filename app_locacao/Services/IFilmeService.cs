using api_locacao.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public interface IFilmeService
    {
        Task<IList<FilmeModel>> GetFilmes();
        Task<FilmeModel> GetFilmeId(int id);
        Task CreateFilme(FilmeModel filme);
        Task UpdateFilme(FilmeModel filme);
        Task DeleteFilme(int id);
    }
}
