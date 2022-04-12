using api_locacao.Model;
using app_locacao.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Controllers
{
    public class LocacoesController : Controller
    {
        private IClienteService _servicoCliente;
        private IFilmeService _servicoFilme;
        private ILocacaoService _servico;

        private IList<ClienteModel> clientes;
        private IList<FilmeModel> filmes;
        private IList<LocacaoModel> locacoes;
        private LocacaoModel locacao;

        public LocacoesController(IClienteService servicoCliente, IFilmeService servicoFilme, ILocacaoService servico)
        {
            _servicoCliente = servicoCliente;
            _servicoFilme = servicoFilme;
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            locacoes = await _servico.GetLocacoes();
            return View(locacoes);
        }

        [HttpGet]
        public async Task<IActionResult> NewLocacao()
        {
            clientes = await _servicoCliente.GetClientes();
            filmes = await _servicoFilme.GetFilmes();

            ViewBag.IdCliente = clientes;
            ViewBag.IdFilme = filmes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewLocacao(LocacaoModel model)
        {
            await _servico.CreateLocacao(model);
            return RedirectToAction("Index");
        }
    }
}
