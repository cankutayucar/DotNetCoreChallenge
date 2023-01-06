using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DotNetChallenge.Application.Features.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o=>o.CompanyId).NotEmpty().NotNull().WithMessage("Firma boş geçilemez");
            RuleFor(o => o.ProductId).NotEmpty().NotNull().WithMessage("Ürün boş geçilemez");
            RuleFor(o => o.NameOfPersonPlacingOrder).NotEmpty().NotNull()
                .WithMessage("Sipariş veren kişinin ismi boş geçilemez");
        }
    }
}
