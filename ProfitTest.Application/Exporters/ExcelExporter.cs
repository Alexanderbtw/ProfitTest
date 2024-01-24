using Microsoft.Extensions.FileProviders;
using OfficeOpenXml;
using ProfitTest.Core.Interfaces.Export;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.Exporters
{
    public class ExcelExporter : IExporter
    {
        public object ExportProducts(IEnumerable<Product> products)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo fileName = new FileInfo("ExcellData.xlsx");
            using var package = new ExcelPackage(fileName);

            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Products");
            ws.Cells.LoadFromCollection(products, true);

            MemoryStream result = new MemoryStream();
            result.Position = 0;

            package.SaveAs(result);

            return result;
        }
    }
}
