using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Application.Wrappers;
using DotNetChallenge.Domain.Entities;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CustomResponse<CreateProductCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(_mapper.Map<CreateProductCommandRequest, Product>(request));
            return CustomResponse<CreateProductCommandResponse>.Success(
                new CreateProductCommandResponse { Text = "Ürün başarıyla eklendi" }, 201);
        }
    }
}
