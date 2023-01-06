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

namespace DotNetChallenge.Application.Features.Queries.GetAllCompany
{
    public class GelAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQueryRequest, CustomResponse<List<GelAllCompanyQueryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public GelAllCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public Task<CustomResponse<List<GelAllCompanyQueryResponse?>>> Handle(GetAllCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var companies =
                _mapper.Map<List<Company>, List<GelAllCompanyQueryResponse>>(_companyRepository.GetAll().ToList());
            return Task.FromResult(CustomResponse<List<GelAllCompanyQueryResponse?>>.Success(companies, 200));
        }
    }
}
