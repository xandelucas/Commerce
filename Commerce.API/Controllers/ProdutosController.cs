using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Domain;
using Commerce.Application;

namespace Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/Produtos
        /// <summary>
        /// Lista todos os produtos cadastrados no sistema.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _produtoService.AtualizaProdutoAsync(produto);
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
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            var createdProduto = await _produtoService.CriaProdutoAsync(produto);
            return CreatedAtAction("GetProdutoById", new { id = createdProduto.Id }, createdProduto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }

             await  _produtoService.DeletaProdutoAsync(produto);
            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _produtoService.GetProdutoByIdAsync(id) is not null ;
        }
    }
}
