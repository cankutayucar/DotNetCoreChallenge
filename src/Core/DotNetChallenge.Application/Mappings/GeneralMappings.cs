using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DotNetChallenge.Application.Features.Commands.CreateCompany;
using DotNetChallenge.Application.Features.Commands.CreateOrder;
using DotNetChallenge.Application.Features.Commands.CreateProduct;
using DotNetChallenge.Application.Features.Queries.GetAllCompany;
using DotNetChallenge.Domain.Entities;

namespace DotNetChallenge.Application.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            // company
            CreateMap<CreateCompanyCommandRequest, Company>().ReverseMap();
            CreateMap<Company, GelAllCompanyQueryResponse>()
                .ForMember(dest => dest.OrderStartTime,
                    opt => opt.MapFrom(x => $"{x.OrderStartTime.Hour}:{x.OrderStartTime.Minute}"))
                .ForMember(dest => dest.OrderEndTime,
                    opt => opt.MapFrom(x => $"{x.OrderEndTime.Hour}:{x.OrderEndTime.Minute}")).ReverseMap();
            // product
            CreateMap<CreateProductCommandRequest, Product>().ReverseMap();
            // order
            CreateMap<CreateOrderCommandRequest, Order>().ForMember(dest => dest.OrderDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
        }
    }
}
