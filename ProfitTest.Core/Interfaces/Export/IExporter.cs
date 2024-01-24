using Microsoft.Extensions.FileProviders;
using ProfitTest.Core.Models;

namespace ProfitTest.Core.Interfaces.Export
{
    public interface IExporter
    {
        object ExportProducts(IEnumerable<Product> products);
    }
}
