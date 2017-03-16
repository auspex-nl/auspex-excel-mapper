using OfficeOpenXml;
using System.Collections.Generic;


namespace Auspex.Excel.Mapper
{
    public interface IExcelMapper
    {
        IEnumerable<T> Map<T>(ExcelPackage excelFile, string sheetName = "") where T : class, new();

        T MapSingleRow<T>(ExcelRange row) where T : class, new();


        ExcelPackage ReadFile(string filename);

    }
}
