using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Domain;
using Commerce.Application.DTOs;
using AutoMapper;
using Commerce.Application.IServices;

namespace Commerce.API.Controllers;
/*
[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriasController(ICategoriaService categoriaService, IMapper mapper)
    {
        _categoriaService = categoriaService;
        _mapper = mapper;
    }

    // GET: api/Categorias
    /// <summary>
    /// Lista todas as categorias cadastradas no sistema.
    /// </summary>
    /// <param name="isAscendente">Ordenação ascendente ou descendente</param>
    /// <param name="nomeCampo">Nome do campo para ordenação</param>
    [HttpGet]
    public async Task<ActionResult<ListaPaginada<CategoriaDTO>>> GetCategoria(bool isAscendente, string nomeCampo = "nome")
    {
        var configuracao = new ConfiguracaoPaginacao();
        var categorias = await _categoriaService.GetAllCategoriasAsync(nomeCampo, configuracao, isAscendente);
        return Ok(categorias);
    }

    // GET: api/Categorias/CategoriaOrdenado
    /// <summary>
    /// Lista todas as categorias cadastradas no sistema com campos para Ordenação.
    /// </summary>
    /// <param name="nomeCampo">Nome do campo para ordenação</param>
    /// <param name="configuracao"></param>
    /// <param name="isAscendente">Ordenação ascendente ou descendente</param>
    [HttpGet("CategoriaOrdenado")]
    public async Task<ActionResult<ListaPaginada<CategoriaDTO>>> GetCategoriaOrdenado(bool isAscendente, [FromQuery] ConfiguracaoPaginacao configuracao, string nomeCampo = "nome")
    {
        var categorias = await _categoriaService.GetAllCategoriasAsync(nomeCampo, configuracao, isAscendente);
        return Ok(categorias);
    }

    // GET: api/Categorias/{id}
    /// <summary>
    /// Busca categoria por Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoriaById(long id)
    {
        var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
        if (categoria is null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    // PUT: api/Categorias/{id}
    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="id">O ID da categoria</param>
    /// <param name="categoriaDto">O DTO da categoria</param>
    /// <returns>Um objeto IActionResult representando o resultado da operação</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(long id, CategoriaDTO categoriaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria is null)
            {
                return NotFound();
            }
            categoriaDto.Id = id;
            await _categoriaService.AtualizaCategoriaAsync(categoriaDto);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CategoriaExists(id))
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

    // POST: api/Categorias
    /// <summary>
    /// Cria uma nova categoria
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoriaDto)
    {
        var createdCategoria = await _categoriaService.CriaCategoriaAsync(categoriaDto);
        return CreatedAtAction("GetCategoriaById", new { id = createdCategoria.Id }, createdCategoria);
    }

    // DELETE: api/Categorias/{id}
    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(long id)
    {
        var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
        if (categoria is null)
        {
            return NotFound();
        }

        await _categoriaService.DeletaCategoriaAsync(categoria.Id);
        return NoContent();
    }

    private async Task<bool> CategoriaExists(long id)
    {
        return await _categoriaService.GetCategoriaByIdAsync(id) is not null;
    }
} */