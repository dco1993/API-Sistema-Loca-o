using api_locacao.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Services
{
    public interface IClienteService
    {
        Task<IList<ClienteModel>> GetClientes();
        Task<ClienteModel> GetClienteId(int id);
        Task CreateCliente(ClienteModel cliente);
        Task UpdateCliente(ClienteModel cliente);
        Task DeleteCliente(int id);
    }
}
