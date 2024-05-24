using Commerce.Application.DTOs;
using Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.IServices;

public interface ICategoriaService
{
    Task<ListaPaginada<CategoriaDTO>> GetAllCategoriasAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true);

    Task<Categoria?> GetCategoriaByIdAsync(long id);

    Task<Categoria> AtualizaCategoriaAsync(CategoriaDTO categoriaDTO);

    Task<Categoria> CriaCategoriaAsync(CategoriaDTO categoriaDTO);

    Task DeletaCategoriaAsync(long categoria);
}
