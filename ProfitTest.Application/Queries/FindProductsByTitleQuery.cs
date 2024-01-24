using MediatR;
using ProfitTest.Application.DTOs;

namespace ProfitTest.Application.Queries
{
    public class FindProductsByTitleQuery : IRequest<List<ProductResponseDTO>>
    {
        public string Title { get; set; }
        public FindProductsByTitleQuery(string title)
        {
            Title = title;
        }
    }
}
