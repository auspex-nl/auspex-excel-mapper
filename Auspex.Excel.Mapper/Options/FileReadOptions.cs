using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Options
{
    [Flags]
    public enum FileReadOptions
    {
        FirstRowContainsFieldNames = 0,
        IgnoreInvalidRows = 1,
    }
}
