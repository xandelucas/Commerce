using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Domain;
using Commerce.Application;
using Commerce.Application.DTOs;
using AutoMapper;

namespace Commerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;

    public ProdutosController(IProdutoService produtoService, IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }

    // GET: api/Produtos
    /// <summary>
    /// Lista todos os produtos cadastrados no sistema.
    /// </summary>
    /// <param name="page">Número da página</param>
    /// <param name="pageSize">Tamanho da página</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProduto(int page = 1, int pageSize = 10)
    {
        var produtos = await _produtoService.GetAllProdutosAsync(nomeCampo: "Id", true, page, pageSize);
        return Ok(produtos);
    }

    // GET: api/Produtos
    /// <summary>
    /// Lista todos os produtos cadastrados no sistema com campos para Ordenação.
    /// </summary>
    /// <param name="nomeCampo">Nome do campo para ordenação</param>
    /// <param name="isAscendente">Ordenação ascendente ou descendente</param>
    /// <param name="pageNumber">Número da página</param>
    /// <param name="pageSize">Tamanho da página</param>
    [HttpGet("ProdutoOrdenado")]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutoOrdenado(string nomeCampo, bool isAscendente, int pageNumber = 1, int pageSize = 10)
    {
        var produtos = await _produtoService.GetAllProdutosAsync(nomeCampo, isAscendente, pageNumber, pageSize);
        return Ok(produtos);
    }

    // GET: api/Produtos/5
    /// <summary>
    /// Busca produto por Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProdutoById(long id)
    {
        var produto = await _produtoService.GetProdutoByIdAsync(id);
        if (produto is null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    // PUT: api/Produtos/5
    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="id">O ID do produto</param>
    /// <param name="produtoDto">O DTO do produto</param>
    /// <returns>Um objeto IActionResult representando o resultado da operação</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(long id, ProdutoDTO produtoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto is null)
            {
                return NotFound();
            }
            produtoDto.Id = id;
            await _produtoService.AtualizaProdutoAsync(produtoDto);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ProdutoExists(id))
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
    /// <summary>
    /// Cria um novo produto
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ProdutoDTO>> PostProduto(ProdutoDTO produtoDto)
    {
        var createdProduto = await _produtoService.CriaProdutoAsync(produtoDto);
        return CreatedAtAction("GetProdutoById", new { id = createdProduto.Id }, createdProduto);
    }

    // DELETE: api/Produtos/5
    /// <summary>
    /// Deleta um produto
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _produtoService.GetProdutoByIdAsync(id);
        if (produto is null)
        {
            return NotFound();
        }

        await _produtoService.DeletaProdutoAsync(produto);
        return NoContent();
    }

    private async Task<bool> ProdutoExists(long id)
    {
        return await _produtoService.GetProdutoByIdAsync(id) is not null;
    }
}
