namespace Winterra.Helpers
{
    public class FileNameHelper
    {
        public static long GetUnixMicrotime()
        {
            var now = DateTime.UtcNow;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)((now - epoch).TotalMilliseconds * 1000); // Convert to microseconds
        }
    }
}