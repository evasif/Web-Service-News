using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using template.Models.DetailDto;
using template.Models.Dto;
using template.Models.Entities;
using template.Models.InputModels;
using template.Repositories.Data;

namespace template.Repository
{
    public class CategoryRepository
    {
        private readonly NewsItemRepository _newsItemRepository = new NewsItemRepository();

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return Mapper.Map<IEnumerable<CategoryDto>>(CategoryDataProvider.Categories);
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            return Mapper.Map<CategoryDetailDto>(CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id));
        }

        public int CreateNewCategory(CategoryInputModel category)
        {
            var nextId = CategoryDataProvider.Categories.Count() + 1;
            var entity = Mapper.Map<Category>(category);
            entity.Id = nextId;
            CategoryDataProvider.Categories.Add(entity);
            return nextId;
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var updateCategory = CategoryDataProvider.Categories.FirstOrDefault(c => c.Id == id);

            if (updateCategory == null) { return; /* Throw some exception */ }

            // Update properties
            updateCategory.Name = category.Name;
            updateCategory.ParentCategoryId = category.ParentCategoryId;
            updateCategory.Slug = category.Slug;
        }

        public void LinkNewsItemToCategory(int Cid, int Nid)
        {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(c => c.Id == Nid);
            newsItem.CategoryId = Cid;
        }

        public void DeleteCategories(int id)
        {
            var entity = Mapper.Map<Category>(CategoryDataProvider.Categories.FirstOrDefault(x => x.Id == id));
            CategoryDataProvider.Categories.Remove(entity);
        }
    }
}