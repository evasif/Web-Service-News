using System;
using System.Collections.Generic;
using template.Extensions;
using template.Models.DetailDto;
using template.Models.Dto;
using template.Models.InputModels;
using template.Repository;

namespace template.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories();

            foreach (CategoryDto category in categories)
            {
                int id = category.Id;
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("href", $"api/categories/{id}");

                category.Links.AddReference("self", dict);
                category.Links.AddReference("edit", dict);
                category.Links.AddReference("delete", dict);
                dict = null;
            }

            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new Exception($"Category with id {id} was not found."); }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("href", $"api/categories/{id}");

            category.Links.AddReference("self", dict);
            category.Links.AddReference("edit", dict);
            category.Links.AddReference("delete", dict);

            dict = null;

            return category;
        }

        public int CreateNewCategory(CategoryInputModel category)
        {
            var slug = category.Name.ToLower().Replace(" ", "-");
            Console.WriteLine(slug);
            category.Slug = slug;

            return _categoryRepository.CreateNewCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = _categoryRepository.GetCategoryById(id);
            if (entity == null) { throw new Exception($"Category with id {id} was not found."); }
            _categoryRepository.UpdateCategoryById(category, id);
        }

        public void LinkNewsItemToCategory(int Cid, int Nid)
        {
            _categoryRepository.LinkNewsItemToCategory(Cid, Nid);
        }

        public void DeleteCategoriesById(int id)
        {
            _categoryRepository.DeleteCategories(id);
        }

    }
}