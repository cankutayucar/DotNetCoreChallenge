using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DotNetChallenge.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty().NotNull().WithMessage("Ürün adı boş geçilemez");
            RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Ürün stoğu 0 dan büyük olmalıdır");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 dan büyük olmalıdır");
        }
    }
}
