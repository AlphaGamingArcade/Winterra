namespace Winterra.Areas.Admin.Models.InputModels
{
    public class SearchFilter
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public string? OrderBy { get; set; }
    }
}