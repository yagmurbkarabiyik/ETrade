using ETrade.Application.Repositories;
using ETrade.Domain.Entities.Common;
using ETrade.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETradeDbContext _context;

        public ReadRepository(ETradeDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public async Task<T> GetByIdAsync(string id)
        //=> await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        => await Table.FindAsync(Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
                => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
                => Table.Where(method);
    }
}
