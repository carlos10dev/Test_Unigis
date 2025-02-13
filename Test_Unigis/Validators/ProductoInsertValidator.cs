using FluentValidation;
using Test_Unigis.DTOs;

namespace Test_Unigis.Validators
{
    public class ProductoInsertValidator : AbstractValidator<ProductoInsertDto>
    {
        public ProductoInsertValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre es obligatorio");
            RuleFor(x => x.FechaCreacion).NotEmpty().WithMessage("La FechaCreacion es obligatorio");
        }
    }
}