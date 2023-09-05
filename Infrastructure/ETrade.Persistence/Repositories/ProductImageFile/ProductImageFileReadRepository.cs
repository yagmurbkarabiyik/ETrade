using ETrade.Application.Repositories;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(ETradeDbContext context) : base(context)
        {
        }
    }
}