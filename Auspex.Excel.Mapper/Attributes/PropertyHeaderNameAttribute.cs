using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PropertyHeaderNameAttribute : Attribute
    {
        public string PropertyHeaderName { get; set; }

        public PropertyHeaderNameAttribute(string propertyHeaderName)
        {
            PropertyHeaderName = propertyHeaderName;
        }
    }
}
