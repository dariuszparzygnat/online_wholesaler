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
        public void Should_ReturnNull_When_IdNotExists()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var findedObject = sut.GetByID(-3);
            findedObject.ShouldBeNull();
        }

        [Fact]
        public void Should_Return7_When_CountOnWholeCollectionOfArticles()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var wholeCollection = sut.Get();
            wholeCollection.Count().ShouldBe(7);
        }

        [Fact]
        public void Should_ReturnOrderedListByName_When_OrderAddedToGet()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var orderedCollection = sut.Get(orderBy: articles => articles.OrderBy(e => e.Name));
            orderedCollection.First().Name.ShouldBe("Cocount");
            orderedCollection.Last().Name.ShouldBe("Tomato");
        }

        [Fact]
        public void Should_Return3Articles_When_FilteredByName()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var filteredCollection = sut.Get(e=>e.Name.StartsWith("C"));
            filteredCollection.Count().ShouldBe(3);
        }

        [Fact]
        public void Should_ReturnEmptyCollection_When_FilteredByNotExistedName()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var filteredCollection = sut.Get(e => e.Name.StartsWith("xxxx"));
            filteredCollection.ShouldNotBeNull();
            filteredCollection.Count().ShouldBe(0);
        }

        [Fact]
        public void Should_ReturnOrderedCollectionWith3Elements_When_FilteredAndOrderedByName()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var filteredAndOrderedCollection = sut.Get(e => e.Name.StartsWith("C"), articles => articles.OrderBy(e=>e.Name));
            filteredAndOrderedCollection.Count().ShouldBe(3);
            filteredAndOrderedCollection.First().Name.ShouldBe("Cocount");
            filteredAndOrderedCollection.Last().Name.ShouldBe("Cucumber");
        }

        [Fact]
        public void Should_DeleteElement_When_DeletedElementUsingExistingId()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            sut.Delete(3);
            dbContext.SaveChanges();
            var searchedElement = sut.GetByID(3);
            searchedElement.ShouldBeNull();
        }

        [Fact]
        public void Should_ThrowsException_When_ExistingIdNotInUseOnDb()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            Should.Throw<ArgumentNullException>(() => sut.Delete(-3));
        }

        [Fact]
        public void Should_DeleteElement_When_DeletedElementExistsAndIsTracked()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var searchedElement = sut.GetByID(3);
            sut.Delete(searchedElement);
            dbContext.SaveChanges();
            searchedElement = sut.GetByID(3);
            searchedElement.ShouldBeNull();
        }

        [Fact]
        public void Should_DeleteElement_When_DeletedElementExistsAndIsNotTracked()
        {
            var options = CreateNewContextOptions();
            using (var dbContext = new WholesalerContext(options))
            {
                dbContext.Articles.AddRange(GetArticlesSet());
                dbContext.SaveChanges();
            }

            using (var dbContext = new WholesalerContext(options))
            {
                var sut = new WholesalerRepository<Article>(dbContext);
                var searchedElement = new Article() { Id = 3, Name = "Onion" };
                sut.Delete(searchedElement);
                dbContext.SaveChanges();
                searchedElement = sut.GetByID(3);
                searchedElement.ShouldBeNull();
            }
        }

        [Fact]
        public void Should_UpdateElement_When_UpdatedElementExistsAndIsTracked()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var searchedElement = sut.GetByID(3);
            var newName = "Apple";
            searchedElement.Name = newName;
            sut.Update(searchedElement);
            dbContext.SaveChanges();
            searchedElement = sut.GetByID(3);
            searchedElement.Name.ShouldBe(newName);
        }

        [Fact]
        public void Should_UpdateElement_When_UpdatedElementExistsAndIsNotTracked()
        {
            var options = CreateNewContextOptions();
            using (var dbContext = new WholesalerContext(options))
            {
                dbContext.Articles.AddRange(GetArticlesSet());
                dbContext.SaveChanges();
            }

            using (var dbContext = new WholesalerContext(options))
            {
                var sut = new WholesalerRepository<Article>(dbContext);
                var newName = "Apple";
                var searchedElement = new Article() { Id = 3, Name = "Onion" };
                searchedElement.Name = newName;
                sut.Update(searchedElement);
                dbContext.SaveChanges();
                searchedElement = sut.GetByID(3);
                searchedElement.Name.ShouldBe(newName);
            }
        }

        [Fact]
        public void Should_ThrowAnException_When_ElementNotExistsAndUpdateIsUsed()
        {
            var dbContext = CreateAndSeedContext();
            var sut = new WholesalerRepository<Article>(dbContext);
            var newId = 10;
            var newName = "Apple";
            var newElement = new Article() { Id = newId, Name = newName };
            Should.Throw<DbUpdateConcurrencyException>(() =>
            {
                sut.Update(newElement);
                dbContext.SaveChanges();
            });
        }



        // TODO: 
        [Fact(Skip = "It would be implemented")]
        public void Should_Include_When_()
        { }



        private WholesalerContext CreateAndSeedContext()
        {
            var options = CreateNewContextOptions();

            var context = new WholesalerContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Articles.AddRange(GetArticlesSet());
            context.SaveChanges();
            return context;
        }

        private static DbContextOptions<WholesalerContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<WholesalerContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
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
