using Microsoft.AspNetCore.Mvc;
using EFAPIDAY2.Services;
using EFAPIDAY2.DTOs.Categories;

namespace EFAPIDAY2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpPost("create-category")]
        public CreateCategoryResponse? CreateCategory([FromBody] CreateCategory createCategory)
        {
            return _categoryService.CreateCategory(createCategory);
        }

        [HttpGet("get-list-all-category")]
        public ActionResult<IEnumerable<CreateCategoryResponse>> GetAll()
        {
            try
            {
                var categories = _categoryService.GetAll();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<CreateCategoryResponse> Get(int id)
        {
            try
            {
                var category = _categoryService.Get(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("delete-category/{id}")]
        public ActionResult<CreateCategoryResponse> DeleteCategory(int id)
        {
            try
            {
                var deletedCategory = _categoryService.DeleteCategory(id);

                return Ok(deletedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("update-category/{id}")]
        public ActionResult<CreateCategoryResponse> UpdateCategory(int id, [FromBody] CreateCategory updateModel)
        {
            if (updateModel == null) return BadRequest();

            try
            {
                var updatedCategory = _categoryService.UpdateCategory(id, updateModel);

                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}