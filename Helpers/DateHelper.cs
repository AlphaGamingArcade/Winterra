namespace Winterra.Helpers
{
	public class DateHelper
	{
		public static DateOnly GetCurrentDate()
		{
			return DateOnly.FromDateTime(DateTime.Now);
		}

		public static DateOnly GetPlusMinusDate(int days)
		{
			return DateOnly.FromDateTime(DateTime.Now.AddDays(days));
		}

	}
}
