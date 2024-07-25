using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.IService;

namespace WebApplication1.ControllerApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesControllerApi : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoriesControllerApi(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _categoryService.AddCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.UpdateCategoryAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id) != null;
        }
    }
}
