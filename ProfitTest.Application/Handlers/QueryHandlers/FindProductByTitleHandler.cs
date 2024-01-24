using AutoMapper;
using MediatR;
using ProfitTest.Application.DTOs;
using ProfitTest.Application.Queries;
using ProfitTest.Core.Interfaces.Services;

namespace ProfitTest.Application.Handlers.QueryHandlers
{
    public class FindProductByTitleHandler : IRequestHandler<FindProductByTitleQuery, ProductResponseDTO>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public FindProductByTitleHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<ProductResponseDTO> Handle(FindProductByTitleQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.FindFirstByTitleAsync(request.Title, cancellationToken).ConfigureAwait(false);
            return _mapper.Map<ProductResponseDTO>(product);
        }
    }
}
