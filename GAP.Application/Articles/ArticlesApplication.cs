using GAP.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Application.Articles
{
    public class ArticlesApplication
    {
        private static String BASE_URL = "";

        public ArticlesApplication() { }

        public ArticlesApplication(String baseUrl)
        {
            BASE_URL = baseUrl;
        }

        public List<Model.Articles> GetAllArticles()
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BASE_URL);

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                String response = _client.GetStringAsync("services/Articles").Result;

                List<Model.Articles> _listArticles = new List<Model.Articles>();
                JObject obj = JObject.Parse(response);

                var articles = obj.SelectTokens("articles").ToList();
                _listArticles = JsonConvert.DeserializeObject<List<Model.Articles>>(articles[0].ToString());

                return _listArticles;
            }
        }


        public Boolean CreateArticle(Model.Articles newArticle)
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BASE_URL);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = _client.PostAsJsonAsync("services/Articles", newArticle).Result;

                return true;
            }
        }


        public Model.Articles GetArticle(int articleId)
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BASE_URL);

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = _client.GetStringAsync($"services/Articles/{articleId}").Result;
               
                JObject obj = JObject.Parse(response);

                var _article = JsonConvert.DeserializeObject<Model.Articles>(
                    obj.SelectTokens("articles").First().ToString());

                return _article;
            }
        }



        public bool UpdateArticle(Model.Articles updArticle)
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BASE_URL);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = _client.PutAsJsonAsync($"services/Articles/{updArticle.Id}", updArticle).Result;

                return true;
            }
        }



        public void DeleteArticle(int articleId)
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(BASE_URL);

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = _client.DeleteAsync($"services/Articles/{articleId}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("401");
                }
            }
        }





    }
}
