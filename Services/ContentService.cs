using Winterra.DataContexts;
using Winterra.Helpers;
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

        private CharacterItemViewModel GetCharacterItemViewModel(Content content) {
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

        private FeatureItemViewModel GetFeatureItemViewModel(Content content) {
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


        private NewsItemViewModel GetNewsItemViewModel(Content content) {
            return new NewsItemViewModel
            {
                Id = content.Id,
                Title = content.Title ?? "",
                PublishDate = content.PublishedAt
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

        private UpdateItemViewModel GetUpdateItemViewModel(Content content) {
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

        private HighlightItemViewModel GetHighlightItemViewModel(Content content) {
            return new HighlightItemViewModel
            {
                // Image = content.Image,
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
            var updateList = _contentDataAccess.GetContentList("update");
            var highlightList = _contentDataAccess.GetContentList("highlight");

            return new HomeIndexViewModel
            {
                CharacterItemList = GetCharacterItemListViewModel(characterList),
                FeatureItemList = GetFeatureItemListViewModel(featureList),
                NewsItemList = GetNewsItemListViewModel(newsList),
                UpdateItemList = GetUpdateItemListViewModel(updateList),
                HighlightItemList = GetHighlightItemListViewModel(highlightList),
            };
        }
    }
}