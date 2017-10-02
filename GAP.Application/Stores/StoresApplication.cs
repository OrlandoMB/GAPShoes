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

namespace GAP.Application.Stores
{
    public class StoresApplication
    {
        public List<Model.Stores> GetAllStores()
        {
    
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri("http://localhost:62046/");

                var byteArray = Encoding.ASCII.GetBytes("my_user:my_password");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = _client.GetStringAsync("services/Stores").Result;

                List<Model.Stores> _listStores = new List<Model.Stores>();
                JObject obj = JObject.Parse(response);

                var stores = obj.SelectTokens("stores").ToList();
                _listStores = JsonConvert.DeserializeObject<List<Model.Stores>>(stores[0].ToString());

                return _listStores;
            }
        }
    }
}
