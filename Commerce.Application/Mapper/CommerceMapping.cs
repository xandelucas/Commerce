using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.Mapper;

public class CommerceMapping : Profile
{
    public CommerceMapping()
    {
        CreateMap<Domain.Produto, DTOs.ProdutoDTO>().ReverseMap();
        CreateMap<Domain.Categoria, DTOs.CategoriaDTO>().ReverseMap();
    }
}
