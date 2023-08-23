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

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        private readonly ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        //[HttpGet]
        //public async Task Get()
        //{
        //    await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.500F, Stock = 45, CreatedDate = DateTime.UtcNow });
        //    await _productWriteRepository.SaveAsync();

        //    var customerId = Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Yağmur" });
        //    await _orderWriteRepository.AddAsync(new() { Description = "Test 1", Address = "Çankaya / Ankara", CustomerId = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "Test 2", Address = "Pursaklar / Ankara", CustomerId = customerId });

        //    await _orderWriteRepository.SaveAsync();

        //    Order order = await _orderReadRepository.GetByIdAsync("2269a190-5cfe-498c-8753-c234e2ad40e6");
        //    order.Address = "asdf";
        //    await _orderWriteRepository.SaveAsync();


        //}


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Merhaba!");
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await  _productReadRepository.GetByIdAsync(id); 
        //    return Ok(product);
        //}
    }
}
