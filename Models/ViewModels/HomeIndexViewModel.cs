namespace Winterra.Models.ViewModels
{
  public class HomeIndexViewModel
  {
    public CharacterItemListViewModel CharacterItemList { get; set; } = new();
    public FeatureItemListViewModel FeatureItemList { get; set; } = new(); 
    public NewsItemListViewModel NewsItemList { get; set; } = new(); 
    public UpdateItemListViewModel UpdateItemList { get; set; } = new(); 
    public HighlightItemListViewModel HighlightItemList { get; set; } = new(); 
	}
}
