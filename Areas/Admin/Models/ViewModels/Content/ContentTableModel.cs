using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
    public class ContentTableModel
    {
        public string? MenuIn { get; set; }
        public List<Content>? Items { get; set; }
    }
}