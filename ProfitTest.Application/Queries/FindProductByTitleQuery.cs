using MediatR;
using ProfitTest.Application.DTOs;

namespace ProfitTest.Application.Queries
{
    public class FindProductByTitleQuery : IRequest<ProductResponseDTO>
    {
        public string Title { get; set; }
        public FindProductByTitleQuery(string title)
        {
            Title = title;
        }
    }
}
