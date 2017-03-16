using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Options
{
    public enum FieldTypeConversionOptions
    {
        None = 0,
        TryConvertOnFieldTypeMismatch = 1,
        ThrowOnFieldTypeMismatch = 2,
        IgnoreFieldTypeMismatch = 4
    }
}
