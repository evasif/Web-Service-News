using System.Collections.Generic;
using template.Models.Dto;
using AutoMapper;
using template.Repositories.Data;
using System.Linq;
using template.Models.DetailDto;
using template.Models.InputModels;
using template.Models.Entities;
using System;

namespace template.Repository
{
    public class NewsItemRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems(int pageSize, int pageNumber)
        {
            return Mapper.Map<IEnumerable<NewsItemDto>>(NewsItemDataProvider.NewsItems.OrderByDescending(x => x.PublishDate));
        }

        public NewsItemDetailDto GetNewsItemById(int id)
        {
            return Mapper.Map<NewsItemDetailDto>(NewsItemDataProvider.NewsItems.FirstOrDefault(n => n.Id == id));
        }

        public int CreateNewNewsItem(NewsItemInputModel item)
        {
            var nextId = NewsItemDataProvider.NewsItems.Count() + 1;
            var entity = Mapper.Map<NewsItem>(item);
            entity.Id = nextId;
            NewsItemDataProvider.NewsItems.Add(entity);
            return nextId;
        }

        public void UpdateNewsItemById(NewsItemInputModel item, int id)
        {
            var updateItem = NewsItemDataProvider.NewsItems.FirstOrDefault(i => i.Id == id);

            if (updateItem == null) { return; /* Throw some exception */ }

            // Update properties
            updateItem.Title = item.Title;
            updateItem.ImgSource = item.ImgSource;
            updateItem.ShortDescription = item.ShortDescription;
            updateItem.LongDescription = item.LongDescription;
            updateItem.PublishDate = item.PublishDate;
            updateItem.ModifiedDate = DateTime.Now;
        }

        public void DeleteItems(int id)
        {
            var entity = Mapper.Map<NewsItem>(NewsItemDataProvider.NewsItems.FirstOrDefault(x => x.Id == id));
            NewsItemDataProvider.NewsItems.Remove(entity);
        }

        public int GetLinkedAuthorId(int id)
        {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(i => i.Id == id);
            return newsItem.AuthorId;
        }

        public int GetLinkedCategoryId(int id)
        {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(i => i.Id == id);
            return newsItem.CategoryId;
        }
    }
}