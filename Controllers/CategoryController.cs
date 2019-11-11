using Microsoft.AspNetCore.Mvc;
using template.Models.InputModels;
using template.Service;

namespace template.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService = new CategoryService();

        // http://localhost:5000/api [GET]
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        // http://localhost:5000/api/categories/5 [GET]
        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_categoryService.GetCategoryById(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) { return StatusCode(412, category); }
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                var id = _categoryService.CreateNewCategory(category);
                return CreatedAtRoute("GetCategoryById", new { id }, null);
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }

        // http://localhost:5000/api/categories/3 [PUT]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategoryById(int id, [FromBody] CategoryInputModel category)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _categoryService.UpdateCategoryById(category, id);

                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }

        // http://localhost:5000/api/categories/5/newsItems/{newsItemId} [PATCH]
        [HttpPatch]
        [Route("{Cid:int}/newsItems/{Nid:int}")]
        public IActionResult LinkNewsItemToCategory(int Cid, int Nid)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _categoryService.LinkNewsItemToCategory(Cid, Nid);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }


        }

        // http://localhost:5000/api/categories/5 [DELETE]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategoriesById(int id)
        {
            var lang = Request.Headers["Authorization"];
            if (lang == "key")
            {
                _categoryService.DeleteCategoriesById(id);
                return NoContent();
            }
            else
            {
                return StatusCode(401, "Key is unauthorized");
            }

        }


    }
}