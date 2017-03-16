using Auspex.Excel.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auspex.Excel.Mapper.Example.cs
{
    public class ExampleClass
    {
        [PropertyHeaderName("ExampleColumnName")]
        public int FirstColumn { get; set; }

        [PropertyHeaderName("Second_column")]
        public string SecondColumn { get; set; }

        [PropertyHeaderName("ThirdColumn")]
        public DateTime ThirdColumn { get; set; }

        [PropertyHeaderName("some_nice_name_here")]
        public int SomeNiceNameHere { get; set; }

        public int NonAnnotatedProperty { get; set; }

        public override string ToString()
        {
            return $"FirstColumn: {FirstColumn}, SecondColumn: {SecondColumn}, ThirdColumn: {ThirdColumn}, SomeNiceNameHere: {SomeNiceNameHere}, NonAnnotatedProperty: {NonAnnotatedProperty}";
        }

    }
}
