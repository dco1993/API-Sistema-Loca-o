using api_locacao.Model;
using app_locacao.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public class LocacaoService : ILocacaoService
    {
        private IApiHandler _handler;
        private readonly string url = "https://sislocacaoapi.azurewebsites.net/api/locacoes/";
        private IList<LocacaoModel> locacoes;
        private LocacaoModel locacao;

        public LocacaoService(IApiHandler handler)
        {
            _handler = handler;
        }

        public async Task<IList<LocacaoModel>> GetLocacoes()
        {
            string result = await _handler.GetData(url);
            locacoes = JsonConvert.DeserializeObject<IList<LocacaoModel>>(result);
            return locacoes;
        }

        public async Task<LocacaoModel> GetLocacaoId(int id)
        {
            string result = await _handler.GetDataId(url + id);
            locacao = JsonConvert.DeserializeObject<LocacaoModel>(result);
            return locacao;
        }

        public async Task CreateLocacao(LocacaoModel locacao)
        {
            string json = JsonConvert.SerializeObject(locacao);
            await _handler.InsertData(url, json);
        }

        public async Task UpdateLocacao(LocacaoModel locacao)
        {
            string json = JsonConvert.SerializeObject(locacao);
            await _handler.UpdateData(url + locacao.Id, json);
        }

        public async Task DeleteLocacao(int id)
        {
            await _handler.DeleteData(url + id);
        }
    }
}
