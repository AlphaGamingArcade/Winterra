using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class ContentViewModel : BaseViewModel
  {
    public string? Search { get; set; }
    public string? SortBy { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public Pagination<Content>? CharacterContentList { get; set; }
    public Pagination<Content>? HighlightContentList { get; set; }
    public Pagination<Content>? LoreContentList { get; set; }
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
