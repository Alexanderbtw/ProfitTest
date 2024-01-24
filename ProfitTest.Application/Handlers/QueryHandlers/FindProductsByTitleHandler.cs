using AutoMapper;
using MediatR;
using ProfitTest.Application.DTOs;
using ProfitTest.Application.Queries;
using ProfitTest.Core.Interfaces.Services;

namespace ProfitTest.Application.Handlers.QueryHandlers
{
    public class FindProductsByTitleHandler : IRequestHandler<FindProductsByTitleQuery, List<ProductResponseDTO>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public FindProductsByTitleHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<List<ProductResponseDTO>> Handle(FindProductsByTitleQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.FindAllByTitleAsync(request.Title, cancellationToken).ConfigureAwait(false);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }
    }
}
