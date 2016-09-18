using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineWholesaler.Domain.Repositories
{
    public class WholesalerRepository<TEntity> : GenericRepository<TEntity, WholesalerContext> where TEntity : class
    {
        public WholesalerRepository(WholesalerContext context) : base(context)
        {
        }
    }
}
