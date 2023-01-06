using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Application.Utils;
using DotNetChallenge.Application.Wrappers;
using DotNetChallenge.Domain.Entities;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommandRequest, CustomResponse<CreateCompanyCommandResponse>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateCompanyCommandResponse>> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<CreateCompanyCommandRequest, Company>(request);
            company.OrderStartTime = CalculeteOrderTime.SetTime(request.OrdersStartTime);
            company.OrderEndTime = CalculeteOrderTime.SetTime(request.OrdersEndTime);
            await _companyRepository.AddAsync(company);
            return CustomResponse<CreateCompanyCommandResponse>.Success(
                new CreateCompanyCommandResponse { Message = "Firma başarıyla oluşturuldu" }, 201);
        }
    }
}
