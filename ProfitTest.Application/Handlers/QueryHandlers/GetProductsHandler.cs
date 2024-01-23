using AutoMapper;
using MediatR;
using ProfitTest.Application.DTOs;
using ProfitTest.Application.Queries;
using ProfitTest.Core.Interfaces;

namespace ProfitTest.Application.Handlers.QueryHandlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductResponseDTO>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }
    }
}
