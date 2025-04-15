using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<Character>? CharacterList { get; set; }
		public IEnumerable<Content>? ContentList { get; set; }
        public IEnumerable<Preview>? PreviewList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}
}
