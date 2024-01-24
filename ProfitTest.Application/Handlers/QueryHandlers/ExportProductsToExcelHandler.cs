using AutoMapper;
using MediatR;
using Microsoft.Extensions.FileProviders;
using ProfitTest.Application.Exporters;
using ProfitTest.Application.Queries;
using ProfitTest.Application.Services;
using ProfitTest.Core.Interfaces.Services;

namespace ProfitTest.Application.Handlers.QueryHandlers
{
    public class ExportProductsToExcelHandler : IRequestHandler<ExportProductsToExcelQuery, object>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ExportProductsToExcelHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<object> Handle(ExportProductsToExcelQuery request, CancellationToken cancellationToken)
        {
            return await _productService.AcceptExport(new ExcelExporter(), cancellationToken).ConfigureAwait(false);
        }
    }
}
