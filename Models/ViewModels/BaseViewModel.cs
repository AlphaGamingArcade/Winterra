namespace Winterra.Models.ViewModels
{
    public class BaseViewModel
    {
        public int MenuOut { get; set; }
        public string? MenuIn { get; set; }
        public required string MenuTitle { get; set; }
    }
}
