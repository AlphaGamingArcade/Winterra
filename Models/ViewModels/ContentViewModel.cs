using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class ContentViewModel : BaseViewModel
  {
    public Pagination<Content>? FeatureContentList { get; set; }
    public Pagination<Content>? NewsContentList { get; set; }
    public Pagination<Content>? UpdateContentList { get; set; }
    public Pagination<Content>? CodeOfConductContentList { get; set; }
    public Pagination<Content>? TermsOfUseContentList { get; set; }
    public Pagination<Content>? PrivacyPolicyContentList { get; set; }
    public Pagination<Content>? PlaybookContentList { get; set; }
    public Account? LoginUserInfo { get; set; }
	}
}
