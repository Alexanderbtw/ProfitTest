using MediatR;
using ProfitTest.Application.DTOs;

namespace ProfitTest.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductResponseDTO>>
    {
    }
}
