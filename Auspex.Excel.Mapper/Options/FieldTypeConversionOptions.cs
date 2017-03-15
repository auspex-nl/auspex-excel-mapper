using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Options
{
    public enum FieldTypeConversionOptions
    {
        TryConvertOnFieldTypeMismatch = 0,
        ThrowOnFieldTypeMismatch = 1,
        IgnoreFieldTypeMismatch = 2
    }
}
