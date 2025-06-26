namespace Winterra.Models.ViewModels
{
    public class FeatureItemListViewModel
    {
        public List<FeatureItemViewModel> ItemList { get; set; } = new();
    }
    public class FeatureItemViewModel
    {
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}