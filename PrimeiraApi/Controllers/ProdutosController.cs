using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Contracts.Request;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.ExtensionMethods;
using PrimeiraApi.Validators;

namespace PrimeiraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly PrimeiraApiContext _context;

        public ProdutosController(PrimeiraApiContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public IEnumerable<Produto> GetProduto()
        {
            return _context.Produto;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto([FromRoute] int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] ProductCreateRequest produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validator = new ProductCreateRequestValidator();
            if (!validator.IsValid(produto))
                return BadRequest(new { error = "Produto invalido!" });

            var prod = produto.ConverteParaProduto();

            var modelValidator = new ProductCreateValidator(_context, prod);
            var errors = modelValidator.IsValid();
            if ( errors.Count() > 0 )
            {
                return BadRequest(new { error = errors });
            }

            _context.Produto.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = prod.ProdutoId }, prod);
        }

        
        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ProdutoId == id);
        }
    }
}