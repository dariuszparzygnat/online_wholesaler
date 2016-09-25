using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineWholesaler.Domain;
using OnlineWholesaler.Domain.Entities;
using OnlineWholesaler.Domain.Repositories;

namespace OnlineWholesaler.Articles
{
    public class ArticlesUnitOfWork : IArticlesUnitOfWork
    {
        private WholesalerContext _context;
        private bool _disposed = false;
        private WholesalerRepository<Article> _articlesRepository;

        public WholesalerRepository<Article> ArticlesRepository
        {
            get
            {

                if (_articlesRepository == null)
                {
                    _articlesRepository = new WholesalerRepository<Article>(_context);
                }
                return _articlesRepository;
            }
        }


        public ArticlesUnitOfWork(WholesalerContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Article> GetArticles(string articleName)
        {
            return ArticlesRepository.Get(e => e.Name.Contains(articleName));
        }

        public IEnumerable<Article> GetArticles()
        {
            return ArticlesRepository.Get();
        }

        public Article GetArticle(int articleId)
        {
            return ArticlesRepository.GetByID(articleId);
        }
    }
}
