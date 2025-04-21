using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class ContentTableModel
    {
        public string? Title { get; set; }
        public string? MenuIn { get; set; }
        public List<Content>? Items { get; set; }
    }
}