using ETrade.Application.Repositories;
using ETrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<ETrade.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETradeDbContext context) : base(context)
        {
        }
    }
}
