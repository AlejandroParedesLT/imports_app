using ImportBackend.Contracts.ImportOrder;
using ImportBackend.Models;
using ImportBackend.Services.ImportOrders;
using Microsoft.AspNetCore.Mvc;

namespace ImportBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportOrdersController : ControllerBase
    {
        private readonly IImportOrderService _importOrderService;

        public ImportOrdersController(IImportOrderService importOrderService)
        {
            _importOrderService = importOrderService;
        }

        [HttpPost]
        public IActionResult CreateImportOrder([FromForm] CreateProviderRequest request)
        {
            var importOrder = new ImportOrder(
                    0
                    , request.UserId
                    , request.ProductId
                    , request.ProviderId
                    , request.Quantity
                    , request.Individualprice
                    , request.Description
                    , DateTime.UtcNow
                    , DateTime.UtcNow
                );
            _importOrderService.CreateImportOrder(importOrder);
            var response = new ProviderResponse(
                    importOrder.Id
                    , importOrder.UserId
                    , importOrder.ProductId
                    , importOrder.ProviderId
                    , importOrder.Quantity
                    , importOrder.Individualprice
                    , importOrder.Description
                    , importOrder.DateCreated
                    , importOrder.DateUpdated
                );
            return CreatedAtAction(
                    nameof(GetImportOrder),
                    routeValues: new { id = importOrder.Id },
                    value: response
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetImportOrder(int id)
        {
            ImportOrder importOrder = _importOrderService.GetImportOrder(id);
            if (importOrder == null)
            {
                return NotFound();
            }
            var response = new ProviderResponse(
                    importOrder.Id
                    , importOrder.UserId
                    , importOrder.ProductId
                    , importOrder.ProviderId
                    , importOrder.Quantity
                    , importOrder.Individualprice
                    , importOrder.Description
                    , importOrder.DateCreated
                    , importOrder.DateUpdated
                );
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetImportOrders()
        {
            IEnumerable<ImportOrder> importOrders = _importOrderService.GetImportOrders();
            var response = importOrders.Select(importOrder => new ProviderResponse(
               importOrder.Id
                    , importOrder.UserId
                    , importOrder.ProductId
                    , importOrder.ProviderId
                    , importOrder.Quantity
                    , importOrder.Individualprice
                    , importOrder.Description
                    , importOrder.DateCreated
                    , importOrder.DateUpdated
            ));
            return Ok(response);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpsertImportOrder(int id, UpsertProviderRequest request)
        {
            ImportOrder importOrder = _importOrderService.GetImportOrder(id);
            if (importOrder == null)
            {
                return NotFound();
            }
            var UpsertImportOrder = new ImportOrder(
                    id
                    , request.UserId
                    , request.ProductId
                    , request.ProviderId
                    , request.Quantity
                    , request.Individualprice
                    , request.Description
                    , request.DateCreated
                    , request.DateUpdated
                );
            _importOrderService.UpsertImportOrder(UpsertImportOrder);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteImportOrder(int id)
        {
            ImportOrder importOrder = _importOrderService.GetImportOrder(id);
            if (importOrder == null)
            {
                return NotFound();
            }
            _importOrderService.DeleteImportOrder(id);
            return Ok(id);
        }
    }
}
