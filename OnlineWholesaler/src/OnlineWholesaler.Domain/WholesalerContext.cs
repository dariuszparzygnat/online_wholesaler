using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineWholesaler.Domain.Entities;

namespace OnlineWholesaler.Domain
{
    public class WholesalerContext : DbContext
    {
        public WholesalerContext(DbContextOptions<WholesalerContext> options)
: base(options)
        { }

        public DbSet<Article> Articles { get; set; }
        public static string Dupa => "Dupa";
    }
}
