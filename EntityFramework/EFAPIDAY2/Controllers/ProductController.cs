using EFAPIDAY2.DTOs.Products;
using EFAPIDAY2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFAPIDAY2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-list-all-product")]
        public ActionResult<IEnumerable<CreateProductResponse>> GetAll()
        {
            try
            {
                var products = _productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<CreateProductResponse> Get(int id)
        {
            try
            {
                var product = _productService.Get(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("create-product")]
        public CreateProductResponse? CreateProduct([FromBody] CreateProduct createProduct)
        {
            return _productService.CreateProduct(createProduct);
        }

        [HttpPut("update-product/{id}")]
        public ActionResult<CreateProductResponse> UpdateProduct(int id, [FromBody] CreateProduct updateModel)
        {
            try
            {
                var updatedProduct = _productService.UpdateProduct(id, updateModel);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public ActionResult<CreateProductResponse> DeleteProduct(int id)
        {
            try
            {
                var isSucceeded = _productService.DeleteProduct(id);
                return Ok(isSucceeded);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}