using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAP.WebApi.Application.Articles;
using GAP.WebApi.Security;

namespace GAP.WebApi.Controllers.Articles
{
    [BasicAuthentication]
    public class ArticlesController : ApiController
    {
        ArticleApplication _articlesApp = new ArticleApplication();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var _allArticles = _articlesApp.GetAllArticles();

            return Ok(
                new
                {
                    articles = _allArticles,
                    success = "true",
                    total_elements = _allArticles.Count()
                });
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var _article = _articlesApp.GetArticle(id);

            return Ok(
                new
                {
                    articles = _article,
                    success = "true",
                    total_elements = 1
                });
        }

        [HttpPost]
        public void Post([FromBody]Model.Articles article)
        {
            _articlesApp.CreateArticle(article);
        }

        [HttpPut]
        public void Put(int id, [FromBody]Model.Articles article)
        {
            _articlesApp.UpdateArticle(article);
        }


        [HttpDelete]
        public void Delete(int id)
        {
            _articlesApp.DeleteArticle(id);
        }
    }
}
