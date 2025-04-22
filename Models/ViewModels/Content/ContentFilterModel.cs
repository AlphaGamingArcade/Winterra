namespace Winterra.Models.ViewModels
{
    public class ContentFilterModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? Search { get; set; }
        public string? MenuIn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string? FormController { get; set; }
        public string? FormAction { get; set; }
    }
}