using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineWholesaler.Domain.Entities;

namespace OnlineWholesaler.Articles
{
    public interface IArticlesUnitOfWork : IDisposable
    {
        IEnumerable<Article> GetArticles(string articleName);
        IEnumerable<Article> GetArticles();
        Article GetArticle(int articleId);
        void AddArticle(Article article);
        void SaveChanges();
    }
}
