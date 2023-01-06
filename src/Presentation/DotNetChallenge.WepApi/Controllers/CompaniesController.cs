using DotNetChallenge.Application.Features.Commands.CreateCompany;
using DotNetChallenge.Application.Features.Commands.UpdateCompany;
using DotNetChallenge.Application.Features.Queries.GetAllCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallenge.WepApi.Controllers
{
    public class CompaniesController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return base.CreateActionResult(await _mediator.Send(new GetAllCompanyQueryRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest request)
        {
            return base.CreateActionResult(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommandRequest request)
        {
            return base.CreateActionResult(await _mediator.Send(request));
        }
    }
}
