using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels 
{
    public class ContentTablePartialModel : BasePartialModel
    {
        public int ContentCount {get; set;}
        public IEnumerable<Content>? ContentList { get; set; }
    }
}