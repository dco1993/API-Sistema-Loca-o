using api_locacao.Model;
using app_locacao.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public class FilmeService : IFilmeService
    {
        private IApiHandler _handler;
        private readonly string url = "https://sislocacaoapi.azurewebsites.net/api/filmes/";
        private IList<FilmeModel> filmes;
        private FilmeModel filme;

        public FilmeService(IApiHandler handler)
        {
            _handler = handler;
        }

        public async Task<IList<FilmeModel>> GetFilmes()
        {
            string result = await _handler.GetData(url);
            filmes = JsonConvert.DeserializeObject<IList<FilmeModel>>(result);
            return filmes;
        }

        public async Task<FilmeModel> GetFilmeId(int id)
        {
            string result = await _handler.GetDataId(url + id);
            filme = JsonConvert.DeserializeObject<FilmeModel>(result);
            return filme;
        }

        public async Task CreateFilme(FilmeModel filme)
        {
            string json = JsonConvert.SerializeObject(filme);
            await _handler.InsertData(url, json);
        }

        public async Task UpdateFilme(FilmeModel filme)
        {
            string json = JsonConvert.SerializeObject(filme);
            await _handler.UpdateData(url + filme.Id, json);
        }

        public async Task DeleteFilme(int id)
        {
            await _handler.DeleteData(url + id);
        }
    }
}
