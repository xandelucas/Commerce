using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Application.Mapper
{
    public class ProdutoMapping : Profile
    {
        public ProdutoMapping()
        {
            CreateMap<Domain.Produto, DTOs.ProdutoDTO>().ReverseMap();
        }
    }
}
