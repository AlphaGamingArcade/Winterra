using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public int AdministratorCount { get; set; }
        public IEnumerable<Account>? AdministratorList { get; set; }
        public int AccountCount { get; set; }
        public int AccountIsOnlineCount { get; set; }
        public IEnumerable<Account>? AccountList { get; set; }
        public IEnumerable<Character>? CharacterList { get; set; }
		public IEnumerable<Content>? ContentList { get; set; }
        public IEnumerable<Preview>? PreviewList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}
}
