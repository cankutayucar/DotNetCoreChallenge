using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Wrappers;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CustomResponse<CreateOrderCommandResponse>>
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public string NameOfPersonPlacingOrder { get; set; }
    }
}
