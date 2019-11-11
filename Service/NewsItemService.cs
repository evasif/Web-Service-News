using System;
using System.Collections.Generic;
using System.Linq;
using template.Extensions;
using template.Models;
using template.Models.DetailDto;
using template.Models.Dto;
using template.Models.InputModels;
using template.Repositories.Data;
using template.Repository;

namespace template.Service
{
    public class NewsItemService
    {
        private readonly NewsItemRepository _newsItemRepository = new NewsItemRepository();

        public Envelope<NewsItemDto> GetAllNewsItems(int pageSize, int pageNumber)
        {
            var newsItems = _newsItemRepository.GetAllNewsItems(pageSize, pageNumber);
            var newsList = newsItems.ToList();

            var skip = (pageNumber * pageSize) - pageSize;
            var items = newsList.Skip(skip).Take(pageSize);
            var maxPages = (int)(Math.Ceiling(newsItems.Count() / (decimal)pageSize));

            foreach (NewsItemDto item in items)
            {
                int itemId = item.Id;
                int authorId = _newsItemRepository.GetLinkedAuthorId(item.Id);
                int categoryId = _newsItemRepository.GetLinkedCategoryId(item.Id);
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("href", $"api/{itemId}");
                Dictionary<string, string> authorDict = new Dictionary<string, string>();
                authorDict.Add("href", $"api/authors/{authorId}");
                Dictionary<string, string> categoryDict = new Dictionary<string, string>();
                categoryDict.Add("href", $"api/categories/{categoryId}");

                item.Links.AddReference("self", dict);
                item.Links.AddReference("edit", dict);
                item.Links.AddReference("delete", dict);
                item.Links.AddReference("authors", authorDict);
                item.Links.AddReference("categories", categoryDict);

                dict = null;
            }

            Envelope<NewsItemDto> envelope = new Envelope<NewsItemDto>();

            envelope.PageNumber = pageNumber;
            envelope.PageSize = pageSize;
            envelope.Items = items;
            envelope.maxPages = maxPages;

            return envelope;
        }

        public NewsItemDetailDto GetNewsItemById(int id)
        {
            var newsItem = _newsItemRepository.GetNewsItemById(id);
            if (newsItem == null) { throw new Exception($"News Item with id {id} was not found."); }

            int itemId = newsItem.Id;
            int authorId = _newsItemRepository.GetLinkedAuthorId(id);
            int categoryId = _newsItemRepository.GetLinkedCategoryId(id);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("href", $"api/{itemId}");
            Dictionary<string, string> authorDict = new Dictionary<string, string>();
            authorDict.Add("href", $"api/authors/{authorId}");
            Dictionary<string, string> categoryDict = new Dictionary<string, string>();
            categoryDict.Add("href", $"api/categories/{categoryId}");

            newsItem.Links.AddReference("self", dict);
            newsItem.Links.AddReference("edit", dict);
            newsItem.Links.AddReference("delete", dict);
            newsItem.Links.AddReference("authors", authorDict);
            newsItem.Links.AddReference("categories", categoryDict);

            dict = null;

            return newsItem;
        }

        public int CreateNewNewsItem(NewsItemInputModel item)
        {
            return _newsItemRepository.CreateNewNewsItem(item);
        }

        public void UpdateNewsItemById(NewsItemInputModel item, int id)
        {
            var entity = _newsItemRepository.GetNewsItemById(id);
            if (entity == null) { throw new Exception($"News Item with id {id} was not found."); }
            _newsItemRepository.UpdateNewsItemById(item, id);
        }

        public void DeleteItemsById(int id)
        {
            _newsItemRepository.DeleteItems(id);
        }
    }
}