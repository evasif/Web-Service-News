using System.Linq;
using Microsoft.AspNetCore.Mvc;
using template.Models.Dto;
using template.Models.InputModels;
using template.Service;

namespace template.Controllers
{
    [Route("api")]
    public class NewsItemController : Controller
    {
        private readonly NewsItemService _newsItemService = new NewsItemService();

        //Default limit of 25 news items pageSize
        //Limit can be changes via query parameter called pageSize
        //The pages can be indexed by a query parameter called pageNumber.
        // http://localhost:5000/api [GET]
        [HttpGet]
        [Route("")]
        public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var newsItems = _newsItemService.GetAllNewsItems(pageSize, pageNumber);

            return Ok(newsItems);
        }

        // http://localhost:5000/api/5 [GET]
        [HttpGet]
        [Route("{id:int}", Name = "GetNewsItemById")]
        public IActionResult GetNewsItemById(int id)
        {
            return Ok(_newsItemService.GetNewsItemById(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel item)
        {
            if (!ModelState.IsValid) { return StatusCode(412, item); }
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                var id = _newsItemService.CreateNewNewsItem(item);
                return CreatedAtRoute("GetNewsItemById", new { id }, null);
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }

        // http://localhost:5000/api/3 [PUT]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateNewsItemById(int id, [FromBody] NewsItemInputModel item)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _newsItemService.UpdateNewsItemById(item, id);

                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }

        // http://localhost:5000/api/5 [DELETE]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteItemsById(int id)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _newsItemService.DeleteItemsById(id);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }
    }
}