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
    public class AuthorRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return Mapper.Map<IEnumerable<AuthorDto>>(AuthorDataProvider.Authors);
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            return Mapper.Map<AuthorDetailDto>(AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id));
        }

        public IEnumerable<NewsItemDto> GetNewsItemsByAuthorId(int id)
        {
            return Mapper.Map<IEnumerable<NewsItemDto>>(NewsItemDataProvider.NewsItems.Where(n => n.AuthorId == id));
        }

        public int CreateNewAuthor(AuthorInputModel author)
        {
            var nextId = AuthorDataProvider.Authors.Count() + 1;
            var entity = Mapper.Map<Author>(author);
            entity.Id = nextId;
            AuthorDataProvider.Authors.Add(entity);
            return nextId;
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var updateAuthor = AuthorDataProvider.Authors.FirstOrDefault(a => a.Id == id);

            if (updateAuthor == null) { return; /* Throw some exception */ }

            // Update properties
            updateAuthor.Name = author.Name;
            updateAuthor.ProfileImgSource = author.ProfileImgSource;
            updateAuthor.Bio = author.Bio;
        }

        public void DeleteAuthors(int id)
        {
            var entity = Mapper.Map<Author>(AuthorDataProvider.Authors.FirstOrDefault(x => x.Id == id));
            AuthorDataProvider.Authors.Remove(entity);
        }

        public void LinkAuthorToNewsItem(int Aid, int Nid)
        {
            var newsItem = NewsItemDataProvider.NewsItems.FirstOrDefault(c => c.Id == Nid);
            newsItem.AuthorId = Aid;
        }
    }
}