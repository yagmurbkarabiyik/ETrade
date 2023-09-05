using ETrade.Application.Repositories;
using ETrade.Domain.Entities;

namespace ETrade.Application
{
    public interface IProductImageFileWriteRepository : IWriteRepository<ETrade.Domain.Entities.ProductImageFile>
    {
    }
}