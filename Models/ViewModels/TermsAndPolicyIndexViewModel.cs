namespace Winterra.Models.ViewModels
{
  public class PrivacyPolicyViewModel : BaseViewModel
  {
    public TermsAndPolicyItemListViewModel TermsAndPolicyItemList { get; set; } = new();
  }
  public class TermsOfUseViewModel : BaseViewModel
  {
    public TermsAndPolicyItemListViewModel TermsAndPolicyItemList { get; set; } = new();
  }
  public class CodeOfConductViewModel : BaseViewModel
  {
    public TermsAndPolicyItemListViewModel TermsAndPolicyItemList { get; set; } = new();
	}
}
