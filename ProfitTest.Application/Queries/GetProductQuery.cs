using MediatR;
using ProfitTest.Application.DTOs;

namespace ProfitTest.Application.Queries
{
    public class GetProductQuery : IRequest<ProductResponseDTO>
    {
        public Guid Id { get; set; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
