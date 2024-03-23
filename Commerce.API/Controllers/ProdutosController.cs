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
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProduto()
        {
            var produtos = _produtoService.GetAllProdutos();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public ActionResult<Produto> GetProdutoById(int id)
        {
            var produto = _produtoService.GetProdutoById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                _produtoService.AtualizaProduto(produto);
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
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            var createdProduto = _produtoService.CriaProduto(produto);
            return CreatedAtAction("GetProdutoById", new { id = createdProduto.Id }, createdProduto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produtoExists = ProdutoExists(id);
            if (!produtoExists)
            {
                return NotFound();
            }

            _produtoService.DeletaProduto(id);
            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _produtoService.GetProdutoById(id) is not null ;
        }
    }
}
