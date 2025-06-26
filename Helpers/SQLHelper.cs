namespace Winterra.Helpers
{
    public class SQLHelper
    {
        public static string SanitizeOrderBy(string? input, HashSet<string> allowedColumns, string defaultColumn = "Id")
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) return defaultColumn;
            return allowedColumns.Contains(input) ? input : defaultColumn;
        }

        public static string SanitizeSortBy(string? input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) return "ASC";
            return input.Equals("ASC", StringComparison.OrdinalIgnoreCase) ? "ASC" : "DESC";
        }
    }
}