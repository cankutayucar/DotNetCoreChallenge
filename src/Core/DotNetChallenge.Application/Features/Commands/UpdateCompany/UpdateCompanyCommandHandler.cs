using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetChallenge.Application.Exceptions;
using DotNetChallenge.Application.Features.Commands.CreateCompany;
using DotNetChallenge.Application.Interfaces.Repository;
using DotNetChallenge.Application.Utils;
using DotNetChallenge.Application.Wrappers;
using DotNetChallenge.Domain.Entities;
using MediatR;

namespace DotNetChallenge.Application.Features.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, CustomResponse<UpdateCompanyCommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CustomResponse<UpdateCompanyCommandResponse>> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);
            if (company == null)
                throw new NotFoundException($"{typeof(Company).Name} Not Found");
            company.OrderStartTime = CalculeteOrderTime.SetTime(request.OrdersStartTime);
            company.OrderEndTime = CalculeteOrderTime.SetTime(request.OrdersEndTime);
            company.IsCompanyConfirmed = request.IsCompanyConfirmed;
            _companyRepository.Update(company);
            return CustomResponse<UpdateCompanyCommandResponse>.Success(
                new UpdateCompanyCommandResponse { Message = "Firma başarıyla güncellendi" }, 201);
        }
    }
}
