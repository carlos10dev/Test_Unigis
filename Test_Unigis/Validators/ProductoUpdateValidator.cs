using FluentValidation;
using Test_Unigis.DTOs;

namespace Test_Unigis.Validators
{
    public class ProductoUpdateValidator : AbstractValidator<ProductoUpdateDto>
    {
        public ProductoUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El id es obligatorio");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El Nombre es obligatorio");
            RuleFor(x => x.FechaCreacion).NotEmpty().WithMessage("La FechaCreacion es obligatorio");
        }
    }
}