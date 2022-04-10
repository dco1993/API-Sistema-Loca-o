using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_locacao.Data;
using api_locacao.Model;

namespace api_locacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public FilmesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeModel>>> GetFilme()
        {
            return await _context.Filme.ToListAsync();
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeModel>> GetFilmeModel(int id)
        {
            var filmeModel = await _context.Filme.FindAsync(id);

            if (filmeModel == null)
            {
                return NotFound();
            }

            return filmeModel;
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmeModel(int id, FilmeModel filmeModel)
        {
            if (id != filmeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Filmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmeModel>> PostFilmeModel(FilmeModel filmeModel)
        {
            _context.Filme.Add(filmeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmeModel", new { id = filmeModel.Id }, filmeModel);
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmeModel(int id)
        {
            var filmeModel = await _context.Filme.FindAsync(id);
            if (filmeModel == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filmeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeModelExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}
