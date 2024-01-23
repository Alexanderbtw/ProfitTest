using AutoMapper;
using MediatR;
using ProfitTest.Application.DTOs;
using ProfitTest.Application.Queries;
using ProfitTest.Core.Interfaces;

namespace ProfitTest.Application.Handlers.QueryHandlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductResponseDTO>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetProductHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            return _mapper.Map<ProductResponseDTO>(product);
        }
    }
}
