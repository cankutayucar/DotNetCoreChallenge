using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Wrappers;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CustomResponse<CreateProductCommandResponse>>
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
    }
}
