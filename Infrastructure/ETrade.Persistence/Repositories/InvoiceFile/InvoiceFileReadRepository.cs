using ETrade.Application.Repositories;
using ETrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<ETrade.Domain.Entities.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ETradeDbContext context) : base(context)
        {
        }
    }
}
