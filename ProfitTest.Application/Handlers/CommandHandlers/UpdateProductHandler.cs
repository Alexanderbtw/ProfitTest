using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProfitTest.Application.Commands;
using ProfitTest.Core.Interfaces.Services;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.Handlers.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UpdateProductHandler(IProductService productService, IMapper mapper, ILogger<CreateProductHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            try
            {
                return await _productService.UpdateAsync(product, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Guid.Empty;
            }
        }
    }
}
