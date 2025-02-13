using AutoMapper;
using Test_Unigis.DTOs;
using Test_Unigis.Models;

namespace Test_Unigis.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductoInsertDto, Producto>();
            CreateMap<Producto, ProductoDto>();
        }
    }
}