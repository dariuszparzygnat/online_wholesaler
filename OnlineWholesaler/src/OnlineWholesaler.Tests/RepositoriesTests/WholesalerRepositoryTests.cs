using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineWholesaler.Domain;
using OnlineWholesaler.Domain.Entities;
using OnlineWholesaler.Domain.Repositories;
using Shouldly;
using Xunit;

namespace OnlineWholesaler.Tests.RepositoriesTests
{
    public class WholesalerRepositoryTests
    {
        /// <summary>
        /// Test's name convention - Should_ExpectedBehavior_When_StateUnderTest example Shoul_ThrowException_When_AgeLessThan18 or Should_FailToWithdrawMoney_ForInvalidAccount 
        /// </summary>
        [Fact]
        public void Should_ReturnOnion_When_IdEquals3()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var findedObject = sut.GetByID(3);
            findedObject.Name.ShouldBe("Onion");
        }

        [Fact]
        public void Should_Return7_When_CountOnWholeCollectionOfArticle()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var findedObject = sut.Get();
            findedObject.Count().ShouldBe(7);
        }

        private WholesalerContext CreateAndSeedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WholesalerContext>();
            optionsBuilder.UseInMemoryDatabase();

            var context = new WholesalerContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Articles.AddRange(GetArticlesSet());
            context.SaveChanges();
            return context;
        }

        private IEnumerable<Article> GetArticlesSet()
        {
            List<Article> articles = new List<Article>();
            articles.Add(new Article() { Id = 1, Name = "Tomato" });
            articles.Add(new Article() { Id = 2, Name = "Cucumber"});
            articles.Add(new Article() { Id = 3, Name = "Onion"});
            articles.Add(new Article() { Id = 4, Name = "Cocount"});
            articles.Add(new Article() { Id = 5, Name = "Orange" });
            articles.Add(new Article() { Id = 6, Name = "Corn" });
            articles.Add(new Article() { Id = 7, Name = "Potato" });
            return articles;
        } 
    }
}
