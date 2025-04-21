using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class ContentTableModel
    {
        public string Title { get; set; } = "Content";
        public string MenuIn { get; set; } = "";
        public string SeeAllAction { get; set; } = "Index";
        public List<Content> Items { get; set; } = new();
    }
}     