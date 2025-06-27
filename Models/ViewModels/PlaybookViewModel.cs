namespace Winterra.Models.ViewModels
{
    public class PlaybookItemListViewModel {
        public List<PlaybookItemViewModel> ItemList { get; set; } = new();
    }

    public class PlaybookItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> ImageList { get; set; } = new();
    }
}