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
    public class LocacoesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LocacoesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Locacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocacaoModel>>> GetLocacao()
        {
            return await _context.Locacao.Include(c => c.Cliente).Include(f => f.Filme).ToListAsync();
        }

        // GET: api/Locacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocacaoModel>> GetLocacaoModel(int id)
        {
            var locacaoModel = await _context.Locacao.Include(c => c.Cliente).Include(f => f.Filme).FirstOrDefaultAsync(c => c.Id == id);

            if (locacaoModel == null)
            {
                return NotFound();
            }

            return locacaoModel;
        }

        // PUT: api/Locacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacaoModel(int id, LocacaoModel locacaoModel)
        {
            if (id != locacaoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(locacaoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoModelExists(id))
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

        // POST: api/Locacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocacaoModel>> PostLocacaoModel(LocacaoModel locacaoModel)
        {
            _context.Locacao.Add(locacaoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocacaoModel", new { id = locacaoModel.Id }, locacaoModel);
        }

        // DELETE: api/Locacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacaoModel(int id)
        {
            var locacaoModel = await _context.Locacao.FindAsync(id);
            if (locacaoModel == null)
            {
                return NotFound();
            }

            _context.Locacao.Remove(locacaoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocacaoModelExists(int id)
        {
            return _context.Locacao.Any(e => e.Id == id);
        }
    }
}
