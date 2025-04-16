using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class HomeViewModel : BaseViewModel
  {
    public IEnumerable<Account>? UserAccountList { get; set; }
    public IEnumerable<Account>? AdminAccountList { get; set; }
    public IEnumerable<Preview>? CharacterPreviewList { get; set; }
    public IEnumerable<Preview>? HighlightPreviewList { get; set; }
    public IEnumerable<Preview>? LorePreviewList { get; set; }
    public IEnumerable<Content>? FeaturesContentList { get; set; }
    public IEnumerable<Content>? NewsContentList { get; set; }
    public IEnumerable<Content>? UpdateContentList { get; set; }
    public IEnumerable<Content>? CodeOfConductContentList { get; set; }
    public IEnumerable<Content>? TermsOfUseContentList { get; set; }
    public IEnumerable<Content>? PrivacyPolicyContentList { get; set; }
    public IEnumerable<Content>? PlaybookContentList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}
}
