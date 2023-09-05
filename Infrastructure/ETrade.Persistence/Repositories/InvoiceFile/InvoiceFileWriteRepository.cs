using ETrade.Application.Repositories;
using ETrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class InvoiceFileWriteRepository : WriteRepository<ETrade.Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(ETradeDbContext context) : base(context)
        {
        }
    }
}
