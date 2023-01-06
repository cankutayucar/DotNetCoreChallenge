using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Exceptions;
using FluentValidation;

namespace DotNetChallenge.Application.Features.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommandRequest>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage("Firma boş geçilemez");
            RuleFor(c => c.OrdersEndTime).NotEmpty().NotNull().WithMessage("Firma sipariş başlangıç saati boş geçilemez");
            RuleFor(c => c.OrdersStartTime).NotEmpty().NotNull().WithMessage("Firma sipariş bitiş saati boş geçilemez");
            RuleFor(c => c.OrdersStartTime).Must(c =>
            {
                try
                {
                    var liste = c.Split(":");
                    var res1 = int.TryParse(liste[0], out _);
                    var res2 = int.TryParse(liste[1], out _);
                    var res3 = liste[0].Count() == 2;
                    var res4 = liste[1].Count() == 2;
                    return res1 && res2 && res3 && res4;
                }
                catch (Exception e)
                {
                    throw new ClientSideException("Saat formatı 08:00 biçiminde olmalıdır");
                }
            }).WithMessage("Saat formatı 08:00 biçiminde olmalıdır");
            RuleFor(c => c.OrdersEndTime).Must(c =>
            {
                try
                {
                    var liste = c.Split(":");
                    var res1 = int.TryParse(liste[0], out _);
                    var res2 = int.TryParse(liste[1], out _);
                    var res3 = liste[0].Count() == 2;
                    var res4 = liste[1].Count() == 2;
                    return res1 && res2 && res3 && res4;
                }
                catch (Exception e)
                {
                    throw new ClientSideException("Saat formatı 08:00 biçiminde olmalıdır");
                }
            }).WithMessage("Saat formatı 08:00 biçiminde olmalıdır");
        }
    }
}
