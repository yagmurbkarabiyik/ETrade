using ETrade.Application.Repositories;
using ETrade.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository,IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(), Name = "Laptop", Price = 10000, CreatedDate = DateTime.UtcNow, Stock =10 },
            //    new() {Id = Guid.NewGuid(), Name = "Mouse", Price = 500, CreatedDate = DateTime.UtcNow, Stock =20 },
            //    new() {Id = Guid.NewGuid(), Name = "Klavye", Price = 2000, CreatedDate = DateTime.UtcNow, Stock =30 }
            //});

            //var count = await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("038a9d17-f0da-4876-9a6f-420928bd776f", false);
            p.Name = "Yağmur";
            _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await  _productReadRepository.GetByIdAsync(id); 
            return Ok(product);
        }
    }
}
