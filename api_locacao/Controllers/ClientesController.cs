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
    public class ClientesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClientesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetClienteModel(int id)
        {
            var clienteModel = await _context.Cliente.FindAsync(id);

            if (clienteModel == null)
            {
                return NotFound();
            }

            return clienteModel;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModel(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> PostClienteModel(ClienteModel clienteModel)
        {
            _context.Cliente.Add(clienteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteModel", new { id = clienteModel.Id }, clienteModel);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteModel(int id)
        {
            var clienteModel = await _context.Cliente.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(clienteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteModelExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
