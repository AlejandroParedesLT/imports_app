using ImportBackend.Contracts.Provider;
using ImportBackend.Models;
using ImportBackend.Services.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace ImportBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService productCategoeryService)
        {
            _providerService = productCategoeryService;
        }

        [HttpPost]
        public IActionResult CreateProvider(CreateProviderRequest request)
        {
            var provider = new Provider(
                    0
                    , request.Name
                    , request.Email
                    , request.PhoneNumber
                    , request.Country
                    , DateTime.UtcNow
                    , DateTime.UtcNow
                );
            _providerService.CreateProvider(provider);

            var response = new ProviderResponse(
                    provider.Id
                    , provider.Name
                    , provider.Email
                    , provider.PhoneNumber
                    , provider.Country
                    , provider.DateCreated
                    , provider.DateUpdated
                );
            return CreatedAtAction(
                    nameof(GetProvider),
                    routeValues: new { id = provider.Id },
                    value: response
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProvider(int id)
        {
            Provider provider = _providerService.GetProvider(id);
            if (provider == null)
            {
                return NotFound();
            }
            var response = new ProviderResponse(
                provider.Id
                , provider.Name
                , provider.Email
                , provider.PhoneNumber
                , provider.Country
                , provider.DateCreated
                , provider.DateUpdated
                );
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetProducts()
        {
            IEnumerable<Provider> providers = _providerService.GetProviders();
            var response = providers.Select(provider => new ProviderResponse(
                 provider.Id
                , provider.Name
                , provider.Email
                , provider.PhoneNumber
                , provider.Country
                , provider.DateCreated
                , provider.DateUpdated
            ));
            return Ok(response);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpsertProduct(int id, UpsertProviderRequest request)
        {
            Provider provider = _providerService.GetProvider(id);
            if (provider == null)
            {
                return NotFound();
            }
            var UpsertProvider = new Provider(
                    id
                    , request.Name
                    , request.Email
                    , request.PhoneNumber
                    , request.Country
                    , request.DateCreated
                    , DateTime.UtcNow
                );
            _providerService.UpsertProvider(UpsertProvider);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            Provider provider = _providerService.GetProvider(id);
            if (provider == null)
            {
                return NotFound();
            }
            _providerService.DeleteProvider(id);
            return Ok(id);
        }
    }
}
