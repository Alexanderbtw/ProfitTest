using ProfitTest.Core.Interfaces.Services;

namespace ProfitTest.Core.Interfaces.Export
{
    public interface IExporter
    {
        void ExportProducts(IProductService productService);
    }
}
