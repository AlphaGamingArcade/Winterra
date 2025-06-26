namespace Winterra.Models.ViewModels
{
    public class UpdateItemListViewModel
    {
        public List<UpdateItemViewModel> ItemList { get; set; } = new();
    }
    public class UpdateItemViewModel
    {
        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}