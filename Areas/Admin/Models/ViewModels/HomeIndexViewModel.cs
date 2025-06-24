using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
 public class HomeIndexViewModel : BaseViewModel
  {
    public int ActivePlayerCount { get; set; }
    public int OnlinePlayerCount { get; set; }
    public decimal InGameStellarCount { get; set; }
    public IEnumerable<Account>? UserAccountList { get; set; }
    public IEnumerable<Account>? AdminAccountList { get; set; }
    public IEnumerable<Content>? CharacterContentList { get; set; }
    public IEnumerable<Content>? HighlightContentList { get; set; }
    public IEnumerable<Content>? LoreContentList { get; set; }
    public IEnumerable<Content>? FeatureContentList { get; set; }
    public IEnumerable<Content>? NewsContentList { get; set; }
    public IEnumerable<Content>? UpdateContentList { get; set; }
    public IEnumerable<Content>? CodeOfConductContentList { get; set; }
    public IEnumerable<Content>? TermsOfUseContentList { get; set; }
    public IEnumerable<Content>? PrivacyPolicyContentList { get; set; }
    public IEnumerable<Content>? PlaybookContentList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}

}