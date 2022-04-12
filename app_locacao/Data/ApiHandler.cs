using api_locacao.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_locacao.Data
{
    public class ApiHandler : IApiHandler
    {
        
        public async Task<string> GetData(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    return json;
                }
            } 

            catch
            {
                throw;
            }

        }

        public async Task<string> GetDataId(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    return json;
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task InsertData(string url, string data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    await client.PostAsync(url, content);
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task UpdateData(string url, string data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    await client.PutAsync(url, content);
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task DeleteData(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    await client.DeleteAsync(url);
                }
            }

            catch
            {
                throw;
            }
        }
    }
}
