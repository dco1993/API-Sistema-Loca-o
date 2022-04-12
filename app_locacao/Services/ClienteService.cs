using api_locacao.Model;
using app_locacao.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public class ClienteService : IClienteService
    {
        private IApiHandler _handler;
        private readonly string url = "https://sislocacaoapi.azurewebsites.net/api/clientes/";
        private IList<ClienteModel> clientes;
        private ClienteModel cliente;

        public ClienteService(IApiHandler handler)
        {
            _handler = handler;
        }

        public async Task<IList<ClienteModel>> GetClientes()
        {
            string result = await _handler.GetData(url);
            clientes = JsonConvert.DeserializeObject<IList<ClienteModel>>(result);
            return clientes;
        }

        public async Task<ClienteModel> GetClienteId(int id)
        {
            string result = await _handler.GetDataId(url+id);
            cliente = JsonConvert.DeserializeObject<ClienteModel>(result);
            return cliente;
        }

        public async Task CreateCliente(ClienteModel cliente)
        {
            string json = JsonConvert.SerializeObject(cliente);
            await _handler.InsertData(url, json);
        }

        public async Task UpdateCliente(ClienteModel cliente)
        {
            string json = JsonConvert.SerializeObject(cliente);
            await _handler.UpdateData(url+cliente.Id, json);
        }

        public async Task DeleteCliente(int id)
        {
            await _handler.DeleteData(url+id);
        }
    }
}
