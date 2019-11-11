using Microsoft.AspNetCore.Mvc;
using template.Models.InputModels;
using template.Service;

namespace template.Controllers
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();

        // http://localhost:5000/api/authors [GET]
        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorService.GetAllAuthors());
        }

        // http://localhost:5000/api/authors/5 [GET]
        [HttpGet]
        [Route("{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(_authorService.GetAuthorById(id));
        }

        // This endpoint should retrieve all news items written by the author with the provided id.
        // http://localhost:5000/api/authors/{authorId}/newsItems [GET]
        [HttpGet]
        [Route("{id:int}/newsItems", Name = "GetNewsItemsByAuthorById")]
        public IActionResult GetNewsItemsByAuthorId(int id)
        {
            return Ok(_authorService.GetNewsItemsByAuthorId(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                var id = _authorService.CreateNewAuthor(author);
                return CreatedAtRoute("GetAuthorById", new { id }, null);
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }
        }

        // http://localhost:5000/api/authors/3 [PUT]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorInputModel author)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _authorService.UpdateAuthorById(author, id);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }
        }

        // http://localhost:5000/api/authors/5 [DELETE]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAuthorsById(int id)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _authorService.DeleteAuthorsById(id);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }

        // http://localhost:5000/api/authors/5/newsItems/{newsItemId} [PATCH]
        [HttpPatch]
        [Route("{Aid:int}/newsItems/{Nid:int}")]
        public IActionResult LinkAuthorToNewsItem(int Aid, int Nid)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _authorService.LinkAuthorToNewsItem(Aid, Nid);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }
    }
}