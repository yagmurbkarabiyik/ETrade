using ETrade.Application.Repositories;
using ETrade.Application.RequestParameters;
using ETrade.Application.ViewModels.Products;
using ETrade.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll().Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size)
                            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();

            return Ok( new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(  _productReadRepository.GetAll(false));
        }
        [HttpPost]
        //model => dış dünyadan gelecek olan veriyi kesinlikle entity türünden bir veriyle karşılamamalıyız
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
           await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,  
                Price = model.Price,    
                Stock= model.Stock
            });
            await _productWriteRepository.SaveAsync();
            //return Ok();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
           Product product = await _productReadRepository.GetByIdAsync(model.Id);
            
            product.Name = model.Name; 
            product.Price = model.Price; 
            product.Stock = model.Stock;

           await _productWriteRepository.SaveAsync();
           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
