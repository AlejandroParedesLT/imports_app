using ImportBackend.Contracts.Product;
using ImportBackend.Models;
using ImportBackend.Services.ProductCategories;
using ImportBackend.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace ImportBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly IProductCategoryService _productCategoryService;

        public ProductsController(IProductService productService)//, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            //_productCategoryService = productCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request, IFormFile image)
        {
            byte[] imageData = null;

            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }
            var product = new Product(
                    0
                    , request.Name
                    , request.Description
                    , DateTime.UtcNow
                    , DateTime.UtcNow
                    , request.ProductCategoryId
                    , imageData
                );
            _productService.CreateProduct( product );
            // Retrieve the created product with ProductCategory eagerly loaded
            product = _productService.GetProduct(product.Id); // Assuming GetProduct retrieves with ProductCategory included
            var response = new ImportOrderResponse(
                    product.Id
                    , product.Name
                    , product.Description
                    , product.DateCreated
                    , product.DateUpdated
                    , product.ProductCategory.Name
                    //, product.ProductCategoryId
                    , product.Image
                );
            return CreatedAtAction(
                    nameof(GetProduct),
                    routeValues: new { id = product.Id },
                    value: response
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            Product product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            var response = new ImportOrderResponse(
                product.Id
                , product.Name
                , product.Description
                , product.DateCreated
                , product.DateUpdated
                , product.ProductCategory.Name
                , product.Image
                );
            return Ok(response);
            
        }

        [HttpGet("GetAll")]
        public IActionResult GetProducts()
        {
            IEnumerable<Product> products = _productService.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            var response = products.Select(product => new ImportOrderResponse(
                product.Id
                , product.Name
                , product.Description
                , product.DateCreated
                , product.DateUpdated
                , product.ProductCategory.Name
                , product.Image
            ));
            return Ok(response);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpsertProduct(int id, UpsertImportOrderRequest request)
        {
            Product product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            var Upsertproduct = new Product(
                    id
                    , request.Name
                    , request.Description
                    , request.DateCreated
                    , DateTime.UtcNow
                    , request.ProductCategoryId
                    , request.Image
                );
            _productService.UpsertProduct(Upsertproduct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.DeleteProduct(id);
            return Ok(id);
        }
    }
}
