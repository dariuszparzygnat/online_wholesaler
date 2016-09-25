using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.v3;
using OnlineWholesaler.Articles;
using OnlineWholesaler.Domain;
using OnlineWholesaler.Domain.Entities;

namespace OnlineWholesaler.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private IArticlesUnitOfWork _unitOfWork;

        public ArticlesController(IArticlesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _unitOfWork.GetArticles();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
