namespace ProfitTest.Core.Interfaces.Export
{
    public interface IExportable
    {
        public void AcceptExport(IExporter exporter);
    }
}
