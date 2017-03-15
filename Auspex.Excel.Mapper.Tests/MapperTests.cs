using System;
using System.IO;
using Xunit;

namespace Auspex.Excel.Mapper.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            using (var package = new ExcelPackage(new FileInfo(@"c:\temp\tmp.xlsx")))
        }
    }
}
