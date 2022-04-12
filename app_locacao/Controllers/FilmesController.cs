using api_locacao.Model;
using app_locacao.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app_locacao.Controllers
{
    public class FilmesController : Controller
    {
        private IFilmeService _servico;
        private IList<FilmeModel> filmes;
        private FilmeModel filme;

        public FilmesController(IFilmeService servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            filmes = await _servico.GetFilmes();
            return View(filmes);
        }

        [HttpGet]
        public async Task<IActionResult> FilmeById(int id)
        {
            filme = await _servico.GetFilmeId(id);
            return View(filme);
        }

        [HttpGet]
        public IActionResult NewFilme() => View();

        [HttpPost]
        public async Task<IActionResult> NewFilme(FilmeModel filme)
        {
            await _servico.CreateFilme(filme);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            filme = await _servico.GetFilmeId(id);
            return View(filme);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FilmeModel filme)
        {
            await _servico.UpdateFilme(filme);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            filme = await _servico.GetFilmeId(id);
            return View(filme);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FilmeModel filme)
        {
            await _servico.DeleteFilme(filme.Id);
            return RedirectToAction("Index");
        }

    }
}
