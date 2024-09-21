using ImportBackend.Contracts.ProductCategory;
using ImportBackend.Models;
using ImportBackend.Services.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ImportBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoeryService)
        {
            _productCategoryService = productCategoeryService;
        }

        [HttpPost]
        public IActionResult CreateProductCategory(CreateProductCategoryRequest request)
        {
            var productCategory = new ProductCategory(
                    0
                    , request.Name
                    , request.Description
                    , DateTime.UtcNow
                    , DateTime.UtcNow
                );
            _productCategoryService.CreateProductCategory(productCategory);

            var response = new ProductCategoryResponse(
                    productCategory.Id
                    , productCategory.Name
                    , productCategory.Description
                    , productCategory.DateCreated
                    , productCategory.DateUpdated
                );
            return CreatedAtAction(
                    nameof(GetProductCategory),
                    routeValues: new { id = productCategory.Id },
                    value: response
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductCategory(int id)
        {
            ProductCategory productCategory = _productCategoryService.GetProductCategory(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            var response = new ProductCategoryResponse(
                productCategory.Id
                , productCategory.Name
                , productCategory.Description
                , productCategory.DateCreated
                , productCategory.DateUpdated
                );
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetProducts()
        {
            IEnumerable<ProductCategory> productCategories = _productCategoryService.GetProductCategories();
            var response = productCategories.Select(product => new ProductCategoryResponse(
                product.Id,
                product.Name,
                product.Description,
                product.DateCreated,
                product.DateUpdated
            ));
            return Ok(response);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpsertProduct(int id, UpsertProductCategoryRequest request)
        {
            ProductCategory productCategory = _productCategoryService.GetProductCategory(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            var UpsertproductCategory = new ProductCategory(
                    id
                    , request.Name
                    , request.Description
                    , request.DateCreated
                    , DateTime.UtcNow
                );
            _productCategoryService.UpsertProductCategory(UpsertproductCategory);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            ProductCategory productCategory = _productCategoryService.GetProductCategory(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            _productCategoryService.DeleteProductCategory(id);
            return Ok(id);
        }
    }
}
