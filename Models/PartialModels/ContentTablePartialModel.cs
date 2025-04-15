using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels 
{
    public class ContentTablePartialModel : BasePartialModel
    {
        public IEnumerable<Content>? ContentList { get; set; }
    }
}