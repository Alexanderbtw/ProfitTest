using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProfitTest.Application.Commands;
using ProfitTest.Core.Interfaces.Services;

namespace ProfitTest.Application.Handlers.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DeleteProductHandler(IProductService productService, IMapper mapper, ILogger<CreateProductHandler> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _productService.RemoveAsync(request.Id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }
    }
}
