using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Wrappers;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateCompany
{
    public class CreateCompanyCommandRequest : IRequest<CustomResponse<CreateCompanyCommandResponse>>
    {
        public string CompanyName { get; set; }
        public bool IsCompanyConfirmed { get; set; }
        public string OrdersStartTime { get; set; }
        public string OrdersEndTime { get; set; }
    }
}
