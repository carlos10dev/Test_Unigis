using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test_Unigis.DTOs;
using Test_Unigis.Models;
using Test_Unigis.Repository;

namespace Test_Unigis.Services
{
    public class ProductoService : ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto>
    {
        private IRepository<Producto> _productoRepository;
        private IMapper _mapper;

        public ProductoService(IRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> Get()
        {
            var productos = await _productoRepository.Get();

            return productos.Select(b => _mapper.Map<ProductoDto>(b));
        }
        
        public async Task<ProductoDto> GetById(int id)
        {
            var producto = await _productoRepository.GetById(id);

            if (producto != null)
            {
                var productoDto = _mapper.Map<ProductoDto>(producto);

                return productoDto;
            }

            return null;
        }

        public async Task<ProductoDto> Add(ProductoInsertDto productoInsertDto)
        {
            var producto = _mapper.Map<Producto>(productoInsertDto);

            await _productoRepository.Add(producto);
            await _productoRepository.Save();

            var productoDto = _mapper.Map<ProductoDto>(producto);

            return productoDto;
        }

        public async Task<ProductoDto> Update(int id, ProductoUpdateDto productoUpdateDto)
        {
            var producto = await _productoRepository.GetById(id);

            if (producto != null)
            {
                producto.Nombre = productoUpdateDto.Nombre;
                producto.Alto = productoUpdateDto.Alto;
                producto.Ancho = productoUpdateDto.Ancho;
                producto.Profundidad = productoUpdateDto.Profundidad;
                producto.Volumen = productoUpdateDto.Volumen;
                producto.Peso = productoUpdateDto.Peso;
                producto.FechaCreacion = productoUpdateDto.FechaCreacion;
                producto.Activo = productoUpdateDto.Activo;

                _productoRepository.Update(producto);
                await _productoRepository.Save();

                var productoDto = _mapper.Map<ProductoDto>(producto);

                return productoDto;
            }

            return null;
        }

        public async Task<ProductoDto> Delete(int id)
        {
            var producto = await _productoRepository.GetById(id);

            if (producto != null)
            {

                var productoDto = _mapper.Map<ProductoDto>(producto);

                _productoRepository.Delete(producto);
                await _productoRepository.Save();          

                return productoDto;
            }

            return null;
        }
            
    }
}