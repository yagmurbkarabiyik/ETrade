using ETrade.Application.Repositories;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETradeDbContext context) : base(context)
        {
        }
    }
}
