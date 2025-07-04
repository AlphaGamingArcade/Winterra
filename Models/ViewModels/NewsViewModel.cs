namespace Winterra.Models.ViewModels
{
    public class NewsItemListViewModel
    {
        public List<NewsItemViewModel> ItemList { get; set; } = new();
    }
    public class NewsItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
    }

    public class NewsTabViewModel
    {
        public string Tab { get; set; } = string.Empty;
    }
}