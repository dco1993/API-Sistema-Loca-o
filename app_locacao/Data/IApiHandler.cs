using api_locacao.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Data
{
    public interface IApiHandler
    {
        Task<string> GetData(string url);
        Task<string> GetDataId(string url);
        Task InsertData(string url, string data);
        Task UpdateData(string url, string data);
        Task DeleteData(string url);
    }
}
