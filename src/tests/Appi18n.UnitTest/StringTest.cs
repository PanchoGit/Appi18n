using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace Appi18n.UnitTest
{
    public class StringTest
    {
        [Fact]
        public void CurrencyTest()
        {
            const int nro = 100;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            var result = nro.ToString("c");

            Assert.Equal("100,00 €", result);
        }

        [Fact]
        public void StringOrder()
        {
            string[] stringArray = { "A", "Æ", "Z" };

            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
            Array.Sort(stringArray);
            var result1 = string.Join("-", stringArray);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Array.Sort(stringArray);
            var result2 = string.Join("-", stringArray);

            Assert.Equal("A-Z-Æ", result1);
            Assert.Equal("A-Æ-Z", result2);
        }
    }
}
