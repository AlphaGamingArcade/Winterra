using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class AccountTableModel
    {
        public string? MenuIn { get; set; }
        public IEnumerable<Account>? Items { get; set; }
    }
}