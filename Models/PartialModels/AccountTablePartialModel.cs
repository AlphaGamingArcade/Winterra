using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels {

    public class AccountTablePartialModel : BasePartialModel
    {
        public int AccountCount { get; set; }
        public IEnumerable<Account>? AccountList { get; set; }
    }
}