using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels 
{
    public class ContentTablePartialModel : BasePartialModel
    {
        public IEnumerable<Preview>? CharacterList { get; set; }
        public IEnumerable<Preview>? HighlightList { get; set; }
        public IEnumerable<Preview>? LoreList { get; set; }
        public IEnumerable<Preview>? FeaturesList { get; set; }


        public IEnumerable<Content>? NewsList { get; set;}
        public IEnumerable<Content>? UpdateList { get; set;}
        public IEnumerable<Content>? CodeOfConductList { get; set;}
        public IEnumerable<Content>? TermsOfUseList { get; set;}
        public IEnumerable<Content>? PrivacyPolicyList { get; set;}
        public IEnumerable<Content>? PlaybookList { get; set;}
    }
}