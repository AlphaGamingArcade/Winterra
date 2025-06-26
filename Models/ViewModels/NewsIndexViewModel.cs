namespace Winterra.Models.ViewModels
{
  public class NewsIndexViewModel : BaseViewModel
  {
    public NewsItemListViewModel NewsItemList { get; set; } = new();
	}
}
