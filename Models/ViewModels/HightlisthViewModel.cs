namespace Winterra.Models.ViewModels
{
    public class HighlightItemListViewModel
    {
        public List<HighlightItemViewModel> ItemList { get; set; } = new();
    }
    public class HighlightItemViewModel
    {
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}