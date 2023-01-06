using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Wrappers;
using MediatR;

namespace DotNetChallenge.Application.Features.Queries.GetAllCompany
{
    public class GetAllCompanyQueryRequest : IRequest<CustomResponse<List<GelAllCompanyQueryResponse>>>
    {
    }
}
