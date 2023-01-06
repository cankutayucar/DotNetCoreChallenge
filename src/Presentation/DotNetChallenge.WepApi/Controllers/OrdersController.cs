using DotNetChallenge.Application.Features.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallenge.WepApi.Controllers
{
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
        {
            return base.CreateActionResult(await _mediator.Send(request));
        }
    }
}
