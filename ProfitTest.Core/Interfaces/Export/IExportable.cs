using Microsoft.Extensions.FileProviders;

namespace ProfitTest.Core.Interfaces.Export
{
    public interface IExportable
    {
        public Task<object> AcceptExport(IExporter exporter, CancellationToken cancellationToken = default);
    }
}
