using ETrade.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //get işlemi yapılır fakat herhangi bir set işlemi yapılmaz    
        DbSet<T> Table { get; }
    }
}
