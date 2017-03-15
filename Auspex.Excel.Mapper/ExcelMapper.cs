using OfficeOpenXml;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Auspex.Excel.Mapper.Exceptions;

namespace Auspex.Excel.Mapper
{
    public class ExcelMapper : IExcelMapper
    {
        private ExcelPackage _package;

        private ExcelPackage Package
        {
            get { return _package; }
            set { _package = value; }
        }

        public IEnumerable<T> Map<T>(ExcelPackage excelFile, string sheetName = "")
        {
            // find the worksheet
            ExcelWorksheet worksheet = null;

            if (!string.IsNullOrWhiteSpace(sheetName))
            {
                worksheet = excelFile.Workbook.Worksheets.FirstOrDefault(w => w.Name == sheetName);
            } else
            {
                worksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
            }

            if (worksheet == null)
            { 
                throw new ExcelMapperException($"Could not find a worksheet with name {sheetName}");
            }

            // determine the amount of columns in the sheet


            return new List<T>();
        }

        public ExcelPackage ReadFile(string filename)
        {
            this.Package = new ExcelPackage(new FileInfo(filename));

            return this.Package;
        }
    }
}
