using AutoMapper;
using ProfitTest.Application.DTOs;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse() 
        {
            CreateMap<Product, ProductResponseDTO>();
        }
    }
}
