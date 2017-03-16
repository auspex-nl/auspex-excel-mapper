using OfficeOpenXml;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Auspex.Excel.Mapper.Exceptions;
using Auspex.Excel.Mapper.Options;
using System.Reflection;
using System;
using Auspex.Excel.Mapper.Attributes;

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

        public FileReadOptions FileReadOptions { get; set; }

        private Dictionary<int, string> Headers { get; set; } = new Dictionary<int, string>();

        public ExcelMapper(FileReadOptions fileReadOptions = (FileReadOptions.FirstRowContainsFieldNames | FileReadOptions.IgnoreInvalidRows))
        {
            FileReadOptions = fileReadOptions;
        }

        public IEnumerable<T> Map<T>(ExcelPackage excelFile, string sheetName = "") where T: class, new()
        {
            // find the worksheet
            ExcelWorksheet worksheet = null;

            if (!string.IsNullOrWhiteSpace(sheetName))
            {
                worksheet = excelFile.Workbook.Worksheets.FirstOrDefault(w => w.Name == sheetName);
            }
            else
            {
                worksheet = excelFile.Workbook.Worksheets.FirstOrDefault();
            }

            if (worksheet == null)
            { 
                throw new ExcelMapperException($"Could not find a worksheet with name {sheetName}");
            }

            // determine the amount of columns in the sheet
            int totalColumns = worksheet.Dimension.End.Column;
            int startRow = 1;
            int endRow = worksheet.Dimension.End.Row;
            Headers = new Dictionary<int,string>();

            // if the first row contains the headers, read them, else generate empty header list
            if ((FileReadOptions & FileReadOptions.FirstRowContainsFieldNames) == FileReadOptions.FirstRowContainsFieldNames)
            {
                startRow = 2;
                int count = 0;
                foreach (var header in worksheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, worksheet.Dimension.Start.Row, totalColumns])
                {
                    Headers.Add(count, header.Text);
                    count++;
                }
            }
            else
            {
                throw new NotImplementedException("Not using FileReadOptions.FirstRowContainsFieldNames is not yet supported");
                //for (int i = 0; i < totalColumns; i++)
                //{
                //    Headers.Add(i, string.Empty);
                //}
            }

            var returnList = new List<T>();
            // foreach row from start to end, map
            for(int i = startRow; i <= endRow; i++)
            {
                var row = MapSingleRow<T>(worksheet.Cells[i, 1, i, totalColumns]);
                if (row != null)
                {
                    returnList.Add(row);
                }
            }

            return returnList;
        }

        private PropertyInfo FindProperty(PropertyInfo[] properties, string headerName)
        {
            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<PropertyHeaderNameAttribute>();
                if (attr != null)
                {
                    if (attr.PropertyHeaderName == headerName)
                    {
                        return prop;
                    }
                }
                else
                {
                    if (prop.Name == headerName)
                    {
                        return prop;
                    }
                }
            }
            return null;
        }


        public T MapSingleRow<T>(ExcelRange row) where T : class,new()
        {
            var output = new T();
            var properties = output.GetType().GetProperties();


            int count = 0;
            foreach (var cell in row)
            {
                PropertyInfo propertyInfo = FindProperty(properties, Headers[count]);

                if (propertyInfo == null)
                {
                    if ((FileReadOptions & FileReadOptions.IgnoreInvalidRows) == FileReadOptions.IgnoreInvalidRows)
                    {
                        return default(T);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"Invalid fieldname {Headers[count]} for cell {count}");
                    }
                }
                propertyInfo.SetValue(output, Convert.ChangeType(cell.Value, propertyInfo.PropertyType));
                count++;
            }

            return output;
        }


        public ExcelPackage ReadFile(string filename)
        {
            this.Package = new ExcelPackage(new FileInfo(filename));

            return this.Package;
        }
    }
}
