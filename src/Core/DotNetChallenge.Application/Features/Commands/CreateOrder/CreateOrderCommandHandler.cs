using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetChallenge.Application.Exceptions;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Application.Wrappers;
using DotNetChallenge.Domain.Entities;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CustomResponse<CreateOrderCommandResponse>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(ICompanyRepository companyRepository, IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _companyRepository = companyRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponse<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _productRepository.GetByIdAsync(request.ProductId) == null)
                throw new NotFoundException($"{typeof(Product).Name} Not Found");
            var company = await _companyRepository.GetByIdAsync(request.CompanyId);
            if (company == null)
                throw new NotFoundException($"{typeof(Company).Name} Not Found");
            if (!CheckOrderTime(company))
                throw new ClientSideException($"Firma şu anda hizmet vermemektedir");
            if (!company.IsCompanyConfirmed)
                throw new ClientSideException($"Firma onaylı değildir");
            var order = _mapper.Map<CreateOrderCommandRequest, Order>(request);
            await _orderRepository.AddAsync(order);
            return CustomResponse<CreateOrderCommandResponse>.Success(
                new CreateOrderCommandResponse { Message = "Siparişiniz başarılı bir şekilde oluşturuldu" }, 201);
        }


        // support methods
        private bool CheckOrderTime(Company company)
        {
            if (company.OrderStartTime.Hour > DateTime.Now.Hour || (company.OrderStartTime.Hour == DateTime.Now.Hour && company.OrderStartTime.Minute > DateTime.Now.Minute) || company.OrderEndTime.Hour < DateTime.Now.Hour || (company.OrderEndTime.Hour == DateTime.Now.Hour && company.OrderEndTime.Minute < DateTime.Now.Minute)) return false;
            return true;
        }

    }
}
