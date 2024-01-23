using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProfitTest.Application.Commands;
using ProfitTest.Application.DTOs;
using ProfitTest.Core.Interfaces;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.Handlers.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CreateProductHandler(IProductService productService, IMapper mapper, ILogger<CreateProductHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            try
            {
                return await _productService.AddAsync(product, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Guid.Empty;
            }
        }
    }
}
