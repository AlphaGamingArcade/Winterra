namespace Winterra.Areas.Admin.Models.ViewModels
{
    public class AccountPageSizesModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? Search { get; set; }
        public string? MenuIn { get; set; }
        public string? FormController { get; set; }
        public string? FormAction { get; set; }
    }
}