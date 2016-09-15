using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace OnlineWholesaler.Domain
{
    public class TemporaryDbContextFactory : IDbContextFactory<WholesalerContext>
    {

        public WholesalerContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<WholesalerContext>();
            builder.UseNpgsql("User ID = postgres; Password = password; Host = localhost; Port = 5432; Database = WholesalerDb; Pooling = true;");
            return new WholesalerContext(builder.Options);
        }
    }
}
