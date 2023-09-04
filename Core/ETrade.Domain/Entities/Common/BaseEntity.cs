using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        //file dosyasında updated date olmaması için virtual tanımlayıp file classında override => not mapped sayesinde orada kullanılmayacak!
        virtual public DateTime UpdatedDate { get; set;}
    }
}
