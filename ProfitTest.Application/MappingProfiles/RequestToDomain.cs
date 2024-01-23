using AutoMapper;
using ProfitTest.Application.Commands;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
