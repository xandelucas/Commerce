using AutoMapper;
using Commerce.Application.DTOs;
using Commerce.Application.IServices;
using Commerce.Domain;
using FluentValidation;


namespace Commerce.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private static CategoriaDTOValidator _categoriaDTOValidator = new();

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        public async Task<Categoria> AtualizaCategoriaAsync(CategoriaDTO categoriaDTO)
        {
            _categoriaDTOValidator.ValidateAndThrow(categoriaDTO);
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.InsertAsync(categoria);
            return categoria;
        }

        public async Task<Categoria> CriaCategoriaAsync(CategoriaDTO categoriaDTO)
        {
            _categoriaDTOValidator.ValidateAndThrow(categoriaDTO);
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.InsertAsync(categoria);
            return categoria;
        }

        public async Task DeletaCategoriaAsync(long id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }

        public async Task<ListaPaginada<CategoriaDTO>> GetAllCategoriasAsync(string nomeCampo, ConfiguracaoPaginacao configuracao, bool isAcendente = true)
        {
            return await _categoriaRepository.GetAllCategoriasAsync( nomeCampo,  configuracao, isAcendente );
        }

        public async Task<Categoria?> GetCategoriaByIdAsync(long id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

    }
    public class CategoriaDTOValidator : AbstractValidator<CategoriaDTO>
    {
        public CategoriaDTOValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MinimumLength(2).MaximumLength(64);
            RuleFor(x => x.Descricao).NotEmpty().MinimumLength(3).MaximumLength(999);
        }
    }
}
