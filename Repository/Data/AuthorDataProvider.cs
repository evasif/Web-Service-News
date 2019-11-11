using System;
using System.Collections.Generic;
using template.Models.Entities;

namespace template.Repositories.Data
{
    public static class AuthorDataProvider
    {
        private static readonly string _adminName = "Admin";
        public static List<Author> Authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "Astrid",
                ProfileImgSource = "https://example.com/authors/1.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 2,
                Name = "John",
                ProfileImgSource = "https://example.com/authors/2.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 3,
                Name = "Eva",
                ProfileImgSource = "https://example.com/authors/3.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 4,
                Name = "Isabella",
                ProfileImgSource = "https://example.com/authors/4.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 5,
                Name = "Pam",
                ProfileImgSource = "https://example.com/authors/5.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 6,
                Name = "Jane",
                ProfileImgSource = "https://example.com/authors/6.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 7,
                Name = "Jim",
                ProfileImgSource = "https://example.com/authors/7.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
            new Author
            {
                Id = 8,
                Name = "Andy",
                ProfileImgSource = "https://example.com/authors/8.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
              new Author
            {
                Id = 9,
                Name = "Angela",
                ProfileImgSource = "https://example.com/authors/9.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            },
              new Author
            {
                Id = 10,
                Name = "Dwight",
                ProfileImgSource = "https://example.com/authors/10.jpg",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ",
                CreatedDate= DateTime.Now,
                ModifiedDate= DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}