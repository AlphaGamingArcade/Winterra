namespace Winterra.Models.ViewModels
{
    public class NewsIndexViewModel : BaseViewModel
    {
        public NewsTabViewModel NewsTab { get; set; } = new();
        public NewsItemListViewModel NewsItemList { get; set; } = new();
    }
    
    public class NewsDetailsVideModel : BaseViewModel
    {
        public NewsItemViewModel NewsItem { get; set; } = new();
        public NewsTabViewModel NewsTab { get; set; } = new();
	}
}
