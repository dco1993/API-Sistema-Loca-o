using api_locacao.Model;
using app_locacao.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Controllers
{
    public class ClientesController : Controller
    {
        private IClienteService _servico;
        private IList<ClienteModel> clientes;
        private ClienteModel cliente;

        public ClientesController(IClienteService servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            clientes = await _servico.GetClientes();
            return View(clientes);
        }

        [HttpGet]
        public async Task<IActionResult> ClienteById(int id)
        {
            cliente = await _servico.GetClienteId(id);
            return View(cliente);
        }

        [HttpGet]
        public IActionResult NewCliente() => View();

        [HttpPost]
        public async Task<IActionResult> NewCliente(ClienteModel model) { 
            await _servico.CreateCliente(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            cliente = await _servico.GetClienteId(id);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClienteModel model)
        {
            await _servico.UpdateCliente(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            cliente = await _servico.GetClienteId(id);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClienteModel cliente)
        {
            await _servico.DeleteCliente(cliente.Id);
            return RedirectToAction("Index");
        }
    }
}
