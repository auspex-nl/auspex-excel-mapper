using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Exceptions
{
    public class ExcelMapperException : Exception
    {
        public ExcelMapperException(string message, Exception innerException = null)
            : base(message, innerException)
        {

        }
    }
}
