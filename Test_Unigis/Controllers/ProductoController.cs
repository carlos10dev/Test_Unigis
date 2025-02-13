using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Unigis.DTOs;
using Test_Unigis.Models;
using Test_Unigis.Services;

namespace Test_Unigis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IValidator<ProductoInsertDto> _productInsertValidator;
        private IValidator<ProductoUpdateDto> _productUpdateValidator;
        private ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto> _productService;
        public ProductoController(
            StoreContext storeContext, 
            IValidator<ProductoInsertDto> productoInsertValidator, 
            IValidator<ProductoUpdateDto> productoUpdateValidator, 
            [FromKeyedServices("productoService")]ICommonService<ProductoDto, ProductoInsertDto, ProductoUpdateDto> productService
            )
        {   
            _productInsertValidator = productoInsertValidator;
            _productUpdateValidator = productoUpdateValidator;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDto>> Get() =>
            await _productService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var productoDto = await _productService.GetById(id);

            return productoDto == null ? NotFound() : Ok(productoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Add(ProductoInsertDto productoInsertDto)
        {
            var validationResult = await _productInsertValidator.ValidateAsync(productoInsertDto);
    
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var productoDto = await _productService.Add(productoInsertDto);            

            return CreatedAtAction(nameof(GetById), new{Id = productoDto.Id}, productoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDto>> Update(int id , ProductoUpdateDto productoUpdateDto)
        {
            var validationResult = await _productUpdateValidator.ValidateAsync(productoUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var productoDto = await _productService.Update(id, productoUpdateDto);

            return productoDto == null ? NotFound() : Ok(productoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productoDto = await _productService.Delete(id);

            return productoDto == null ? NotFound() : Ok(productoDto);
        }
    }
}