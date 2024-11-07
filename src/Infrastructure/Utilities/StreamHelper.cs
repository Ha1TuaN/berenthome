using Syncfusion.XlsIO;

namespace TD.KCN.WebApi.Infrastructure.Utilities;

public static class StreamHelper
{

    public static IWorksheet ReadExcel(MemoryStream memoryStream, int? sheetIndex)
    {
        if (!sheetIndex.HasValue)
            sheetIndex = 0;
        var excelEngine = new ExcelEngine();
        IApplication application = excelEngine.Excel;

        var workbook = application.Workbooks.Open(memoryStream, ExcelOpenType.Automatic);
        return workbook.Worksheets[sheetIndex.Value];
    }
}