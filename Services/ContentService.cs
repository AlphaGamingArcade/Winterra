using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Infrastructure.Exceptions;
using Winterra.Models.DataModels;
using Winterra.Models.ViewModels;

namespace Winterra.Services
{
    public class ContentService
    {
        private readonly ContentDataAccess _contentDataAccess;
        public ContentService(ContentDataAccess contentDataAccess)
        {
            _contentDataAccess = contentDataAccess;
        }

        private CharacterItemViewModel GetCharacterItemViewModel(Content content)
        {
            return new CharacterItemViewModel
            {
                Image = StringHelper.ExtractImageSrc(content.Data ?? string.Empty),
                Name = content.Title ?? "",
            };
        }

        private CharacterItemListViewModel GetCharacterItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetCharacterItemViewModel);
            return new CharacterItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        private FeatureItemViewModel GetFeatureItemViewModel(Content content)
        {
            return new FeatureItemViewModel
            {
                Image = StringHelper.ExtractImageSrc(content.Data ?? string.Empty),
                Title = content.Title ?? "",
                Description = StringHelper.ExtractFirstParagraph(content.Data ?? string.Empty),
            };
        }

        private FeatureItemListViewModel GetFeatureItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetFeatureItemViewModel);
            return new FeatureItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }


        private NewsItemViewModel GetNewsItemViewModel(Content content)
        {
            return new NewsItemViewModel
            {
                Id = content.Id,
                Title = content.Title ?? "",
                PublishDate = content.PublishedAt,
                Image = StringHelper.ExtractImageSrc(content.Data ?? ""),
                Content = content.Data ?? ""
            };
        }

        private NewsItemListViewModel GetNewsItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetNewsItemViewModel);
            return new NewsItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        private UpdateItemViewModel GetUpdateItemViewModel(Content content)
        {
            return new UpdateItemViewModel
            {
                Image = StringHelper.ExtractImageSrc(content.Data ?? string.Empty),
                Title = content.Title ?? "",
            };
        }

        private UpdateItemListViewModel GetUpdateItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetUpdateItemViewModel);
            return new UpdateItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        private HighlightItemViewModel GetHighlightItemViewModel(Content content)
        {
            return new HighlightItemViewModel
            {
                Image = StringHelper.ExtractImageSrc(content.Data ?? string.Empty),
                Name = content.Title ?? "",
            };
        }

        private HighlightItemListViewModel GetHighlightItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetHighlightItemViewModel);
            return new HighlightItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }


        public HomeIndexViewModel GetHomeIndexViewModel()
        {
            var characterList = _contentDataAccess.GetContentList("characters");
            var featureList = _contentDataAccess.GetContentList("features");
            var newsList = _contentDataAccess.GetContentList("news");
            var updateList = _contentDataAccess.GetContentList("updates");
            var highlightList = _contentDataAccess.GetContentList("highlights");

            return new HomeIndexViewModel
            {
                MenuOut = 1,
                CharacterItemList = GetCharacterItemListViewModel(characterList),
                FeatureItemList = GetFeatureItemListViewModel(featureList),
                NewsItemList = GetNewsItemListViewModel(newsList),
                UpdateItemList = GetUpdateItemListViewModel(updateList),
                HighlightItemList = GetHighlightItemListViewModel(highlightList),
            };
        }


        private LoreItemViewModel GetLoreItemViewModel(Content content)
        {
            return new LoreItemViewModel
            {
                Id = content.Id,
                ImageList = StringHelper.ExtractImageSrcList(content.Data ?? ""),
                Title = content.Title ?? "",
                Content = content.Data ?? ""
            };
        }

        private LoreItemListViewModel GetLoreItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetLoreItemViewModel);
            return new LoreItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        private StellarItemViewModel GetStellarItemViewModel(Content content)
        {
            return new StellarItemViewModel
            {
                Id = content.Id,
                Title = content.Title ?? "",
                Content = content.Data ?? ""
            };
        }

        private TermsAndPolicyItemViewModel GetTermsAndPolicyItemViewModel(Content content)
        {
            return new TermsAndPolicyItemViewModel
            {
                Id = content.Id,
                Title = content.Title ?? "",
                Content = content.Data ?? ""
            };
        }


        private TermsAndPolicyItemListViewModel GetTermsAndPolicyItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetTermsAndPolicyItemViewModel);
            return new TermsAndPolicyItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        private StellarItemListViewModel GetStellarItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetStellarItemViewModel);
            return new StellarItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }


        public LoreIndexViewModel GetLoreIndexViewModel()
        {
            var loreList = _contentDataAccess.GetContentList("lore");
            return new LoreIndexViewModel
            {
                MenuOut = 2,
                LoreItemList = GetLoreItemListViewModel(loreList)
            };
        }

        public LoreDetailsViewModel GetLoreDetailsViewModel(long id)
        {
            var lore = _contentDataAccess.GetContentData(id);
            if (lore == null)
            {
                throw new NotFoundException("Lore not found");
            }
            return new LoreDetailsViewModel
            {
                MenuOut = 2,
                Item = GetLoreItemViewModel(lore)
            };
        }

        // News
        public NewsIndexViewModel GetNewsIndexViewModel(string? t)
        {
            var tab = t ?? "latest";

            var contentList = tab switch
            {
                "latest" => _contentDataAccess.GetContentListByTypeList(new List<string> { "news", "updates", "events" }),
                "news" => _contentDataAccess.GetContentList("news"),
                "updates" => _contentDataAccess.GetContentList("updates"),
                "events" => _contentDataAccess.GetContentList("events"),
                _ => _contentDataAccess.GetContentList("news")
            };

            return new NewsIndexViewModel
            {
                MenuOut = 3,
                NewsItemList = GetNewsItemListViewModel(contentList),
                NewsTab = new NewsTabViewModel { Tab = tab }
            };
        }
        
        public NewsDetailsVideModel GetNewsDetailsViewModel(long id, string? t)
        {
            var tab = t ?? "latest";
            var content = _contentDataAccess.GetContentData(id);
            if (content == null)
            {
                throw new NotFoundException($"Content not found ID: {id}");
            }

            return new NewsDetailsVideModel
            {
                MenuOut = 3,
                NewsItem = GetNewsItemViewModel(content),
                NewsTab = new NewsTabViewModel { Tab = tab }
            };
        }

        // Stellar
        public StellarIndexViewModel GetStellarIndexViewModel()
        {
            var newsList = _contentDataAccess.GetContentList("stellar");
            return new StellarIndexViewModel
            {
                MenuOut = 4,
                StellarItemList = GetStellarItemListViewModel(newsList),
            };
        }

        private PlaybookItemViewModel GetPlaybookItemViewModel(Content content)
        {
            return new PlaybookItemViewModel
            {
                Id = content.Id,
                Title = content.Title ?? "",
                Content = content.Data ?? ""
            };
        }

        private PlaybookItemListViewModel GetPlaybookItemListViewModel(List<Content> contentList)
        {
            var contentItemList = contentList.Select(GetPlaybookItemViewModel);
            return new PlaybookItemListViewModel
            {
                ItemList = contentItemList.ToList(),
            };
        }

        // Playbook
        public PlaybookIndexViewModel GetPlaybookIndexViewModel()
        {
            var newsList = _contentDataAccess.GetContentList("playbook");
            return new PlaybookIndexViewModel
            {
                MenuOut = 5,
                PlaybookItemList = GetPlaybookItemListViewModel(newsList),
            };
        }

        // TERMS & POLICIES
        public PrivacyPolicyViewModel GetPrivacyPolicyViewModel()
        {
            var newsList = _contentDataAccess.GetContentList("privacy-policy");
            return new PrivacyPolicyViewModel
            {
                MenuOut = 6,
                TermsAndPolicyItemList = GetTermsAndPolicyItemListViewModel(newsList),
            };
        }

        public TermsOfUseViewModel GetTermsOfUsViewModel()
        {
            var newsList = _contentDataAccess.GetContentList("terms-of-use");
            return new TermsOfUseViewModel
            {
                MenuOut = 6,
                TermsAndPolicyItemList = GetTermsAndPolicyItemListViewModel(newsList),
            };
        } 
        
        public CodeOfConductViewModel GetCodeOfConductViewModel()
        {
            var newsList = _contentDataAccess.GetContentList("code-of-conduct");
            return new CodeOfConductViewModel
            {
                MenuOut = 6,
                TermsAndPolicyItemList = GetTermsAndPolicyItemListViewModel(newsList),
            };
        } 
    }
}