using OfficeOpenXml;
using System.Collections.Generic;


namespace Auspex.Excel.Mapper
{
    public interface IExcelMapper
    {
        IEnumerable<T> Map<T>(ExcelPackage excelFile);

        ExcelPackage ReadFile(string filename);

    }
}
