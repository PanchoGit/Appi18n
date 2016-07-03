using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace Appi18n.UnitTest
{
    public class DateTimeTest
    {
        [Fact]
        public void UtcNoOffestTest()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

            var offest = timeZone.BaseUtcOffset;

            Assert.Equal(0, offest.Ticks);
        }

        [Fact]
        public void DateParseWithZuluTest()
        {
            var date1 = DateTime.Parse("2016-06-26T10:32:00");
            var date2 = DateTime.Parse("2016-06-26T10:32:00Z");

            var offset = TimeZoneInfo.Local.BaseUtcOffset;

            if (offset.Ticks != 0)
            {
                Assert.NotEqual(date1, date2);
            }
            else
            {
                Assert.Equal(date1, date2);
            }
        }

        [Fact]
        public void DateKindsTest()
        {
            var date1 = DateTime.Parse("2016-06-26T10:32:00");
            var date2 = DateTime.Parse("2016-06-26T10:32:00Z");
            var date3 = DateTime.UtcNow;
            var date4 = DateTime.SpecifyKind(date1, DateTimeKind.Utc);
            var date5 = DateTimeOffset.Parse("2016-06-26T10:32:00Z").UtcDateTime;
            var date6 = DateTimeOffset.Parse("2016-06-26T10:32:00Z");

            Assert.Equal(DateTimeKind.Unspecified, date1.Kind);
            Assert.Equal(DateTimeKind.Local, date2.Kind);
            Assert.Equal(DateTimeKind.Utc, date3.Kind);
            Assert.Equal(DateTimeKind.Utc, date4.Kind);
            Assert.Equal(DateTimeKind.Utc, date5.Kind);

            Assert.NotEqual(date1, date2);
            Assert.Equal(date1, date4);
            Assert.Equal(date6.LocalDateTime, date2);
            Assert.Equal(date6.UtcDateTime, date4);

            Assert.Equal(DateTimeKind.Local, DateTime.Now.Kind);
            Assert.Equal(DateTimeKind.Utc, DateTime.UtcNow.Kind);
        }

        [Fact]
        public void DateWithCulture()
        {
            var cultureinfo = new CultureInfo("fr-CH");
            var format = "yyyy-MM-dd'T'hh:mm:ss'Z'"; //ISO8601 

            Thread.CurrentThread.CurrentCulture = cultureinfo;

            var date1 = DateTime.Parse("2016-06-26T10:34:00", cultureinfo);
            var date2 = DateTime.Parse("2016-06-26T10:34:00Z", cultureinfo);
            var date3 = DateTime.ParseExact("2016-06-26T10:34:00Z", 
                format,
                cultureinfo.DateTimeFormat,
                DateTimeStyles.AssumeLocal);

            Assert.Equal(10, date1.Hour);
            Assert.Equal(7, date2.Hour);
            Assert.Equal(10, date3.Hour);
        }
    }
}
