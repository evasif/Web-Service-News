using System;
using System.Collections.Generic;
using template.Extensions;
using template.Models.DetailDto;
using template.Models.Dto;
using template.Models.InputModels;
using template.Repository;

namespace template.Service
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();
        private readonly NewsItemRepository _newsItemRepository = new NewsItemRepository();

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();


            foreach (AuthorDto author in authors)
            {
                int id = author.Id;

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("href", $"api/authors/{id}");
                Dictionary<string, string> authorDict = new Dictionary<string, string>();
                authorDict.Add("href", $"api/authors/{id}/newsItems");
                Dictionary<string, string> itemDict = new Dictionary<string, string>();
                itemDict.Add("href", $"api/{id}");

                author.Links.AddReference("self", dict);
                author.Links.AddReference("edit", dict);
                author.Links.AddReference("delete", dict);
                author.Links.AddReference("newsItems", authorDict);
                author.Links.AddReference("newsItemsDetailed", itemDict);

                dict = null;
            }
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new Exception($"Author with id {id} was not found."); }

            int authorId = author.Id;

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("href", $"api/authors/{authorId}");
            Dictionary<string, string> authorDict = new Dictionary<string, string>();
            authorDict.Add("href", $"api/authors/{authorId}/newsItems");
            Dictionary<string, string> itemDict = new Dictionary<string, string>();
            itemDict.Add("href", $"api/{authorId}");

            author.Links.AddReference("self", dict);
            author.Links.AddReference("edit", dict);
            author.Links.AddReference("delete", dict);
            author.Links.AddReference("newsItems", authorDict);
            author.Links.AddReference("newsItemsDetailed", itemDict);

            dict = null;

            return author;
        }

        public IEnumerable<NewsItemDto> GetNewsItemsByAuthorId(int id)
        {
            var items = _authorRepository.GetNewsItemsByAuthorId(id);

            foreach (NewsItemDto item in items)
            {
                int itemId = item.Id;
                int authorId = _newsItemRepository.GetLinkedAuthorId(item.Id);
                int categoryId = _newsItemRepository.GetLinkedCategoryId(item.Id);
                item.Links.AddReference("self", $"http://localhost:5000/api/{itemId}");
                item.Links.AddReference("edit", $"http://localhost:5000/api/{itemId}");
                item.Links.AddReference("delete", $"http://localhost:5000/api/{itemId}");
                item.Links.AddReference("authors", $"http://localhost:5000/api/authors/{id}");
                item.Links.AddReference("categories", $"http://localhost:5000/api/categories/{categoryId}");
            }

            return items;
        }

        public int CreateNewAuthor(AuthorInputModel author)
        {
            return _authorRepository.CreateNewAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var entity = _authorRepository.GetAuthorById(id);
            if (entity == null) { throw new Exception($"Author with id {id} was not found."); }
            _authorRepository.UpdateAuthorById(author, id);
        }

        public void DeleteAuthorsById(int id)
        {
            _authorRepository.DeleteAuthors(id);
        }

        public void LinkAuthorToNewsItem(int Aid, int Nid)
        {
            _authorRepository.LinkAuthorToNewsItem(Aid, Nid);
        }
    }
}