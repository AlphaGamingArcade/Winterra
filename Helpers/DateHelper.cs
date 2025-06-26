namespace Winterra.Helpers
{
public static class DateHelper
		{
			private const string DefaultTimeZone = "Asia/Manila";

			public static DateOnly GetCurrentDate(string timeZoneId = DefaultTimeZone)
			{
				return DateOnly.FromDateTime(GetCurrentDateTime(timeZoneId));
			}

			public static DateOnly GetPlusMinusDate(int days, string timeZoneId = DefaultTimeZone)
			{
				return DateOnly.FromDateTime(GetCurrentDateTime(timeZoneId).AddDays(days));
			}

			public static DateTime GetCurrentDateTime(string timeZoneId = DefaultTimeZone)
			{
				var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
				return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
			}

			public static DateTimeOffset GetPlusMinusDatetimeOffset(int days, string timeZoneId = DefaultTimeZone)
			{
				var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
				var offset = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
				return new DateTimeOffset(offset, tz.GetUtcOffset(offset)).AddDays(days);
			}
		}
}
