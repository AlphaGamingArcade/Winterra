namespace Winterra.Models.ViewModels
{
    public class LoreItemListViewModel {
        public List<LoreItemViewModel> ItemList { get; set; } = new();
    }

    public class LoreItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}