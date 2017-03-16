using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Options
{
    [Flags]
    public enum FileReadOptions
    {
        None = 0,
        FirstRowContainsFieldNames = 1,
        IgnoreInvalidRows = 2,
    }
}
