using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class AccountTableModel
    {
        public string Title { get; set; } = "Account";
        public string MenuIn { get; set; } = "";
        public string SeeAllAction { get; set; } = "Index";
        public List<Account> Items { get; set; } = new();
    }
}