namespace Winterra.Models.ViewModels
{
    public class CharacterItemListViewModel
    {
        public List<CharacterItemViewModel> ItemList { get; set; } = new();
    }
    public class CharacterItemViewModel
    {
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}