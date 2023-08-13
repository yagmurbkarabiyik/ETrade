using ETrade.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Repositories
{
    //select
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //sorgu üzerinde çalışmak için IQueryable | in memoryde çalışmak için IEnumerable
        //List<> => IEnumerable
       IQueryable<T> GetAll();
       IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

       //şarta uygun olan ilkini getirecek
       Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
       Task<T> GetByIdAsync(string id);   
    }
}
