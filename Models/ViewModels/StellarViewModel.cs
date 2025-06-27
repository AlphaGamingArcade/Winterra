namespace Winterra.Models.ViewModels
{
    public class StellarItemListViewModel
    {
        public List<StellarItemViewModel> ItemList { get; set; } = new();
    }
    public class StellarItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}