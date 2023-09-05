using ETrade.Application;
using ETrade.Application.Repositories;
using ETrade.Application.RequestParameters;
using ETrade.Application.Services;
using ETrade.Application.ViewModels.Products;
using ETrade.Domain.Entities;
using ETrade.Persistence.Repositories;
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

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IFileReadRepository _fileReadRepository;

        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        private readonly IInvoiceFileWriteRepository _invoiceWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository
,
            IProductImageFileReadRepository productImageFileReadRepository,
            IInvoiceFileReadRepository invoiceFileReadRepository,
            IInvoiceFileWriteRepository invoiceWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;

            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;

            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;

            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceWriteRepository = invoiceWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
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

            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetAll(false));
        }
        [HttpPost]
        //model => dış dünyadan gelecek olan veriyi kesinlikle entity türünden bir veriyle karşılamamalıyız
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
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

            return Ok(new
            {
                message = "Deleted!"
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _fileService.UploadAsync("resources/product-images", Request.Form.Files);
            //    _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //    {
            //        FileName = d.fileName,
            //        Path = d.path
            //    }).ToList()); ;

            //    await _productImageFileWriteRepository.SaveAsync();

            
            
            return Ok();
        }
    }

}