using System;
using System.Collections.Generic;
using template.Models.Entities;

namespace template.Repositories.Data
{
    public static class CategoryDataProvider
    {
        private static readonly string _adminName = "Admin";
        public static List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Gadgets",
                Slug = "gadgets",
                ParentCategoryId  = 1,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 2,
                Name = "Computer Science",
                Slug = "computer-science",
                ParentCategoryId  = 2,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 3,
                Name = "Science",
                Slug = "science",
                ParentCategoryId  = 3,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 4,
                Name = "Electric Cars",
                Slug = "electric-cars",
                ParentCategoryId  = 4,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 5,
                Name = "Phones",
                Slug = "phones",
                ParentCategoryId  = 5,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 6,
                Name = "Keyboards",
                Slug = "keyboards",
                ParentCategoryId  = 6,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 7,
                Name = "Speakers",
                Slug = "speakers",
                ParentCategoryId  = 7,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 8,
                Name = "Desktop",
                Slug = "desktop",
                ParentCategoryId  = 9,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 9,
                Name = "Laptop",
                Slug = "laptop",
                ParentCategoryId  = 9,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Category
            {
                Id = 10,
                Name = "Apple",
                Slug = "apple",
                ParentCategoryId  = 9,
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}