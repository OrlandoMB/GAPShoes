using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using GAP.Model;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace GAP_OrlandoMorales
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCodeFirst();
            //Algodon().Wait();
            CallSingleObject();
        }



        public static void CallSingleObject()
        {
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri("http://localhost:62046/");

                var response = _client.GetStringAsync("services/Articles/1").Result;

                Articles _article = new Articles();

                JObject obj = JObject.Parse(response);

                var articles = obj.SelectTokens("articles");
                _article = JsonConvert.DeserializeObject<Articles>(articles.First().ToString());
            }
        }




        //public static void TestCodeFirst()
        //{

        //    Console.WriteLine("Init Database");
        //    var shoesContext = new GAP.Persistence.DBContext.GAPShoesDbContext();

        //    var tt = (from ii in shoesContext.Stores
        //             select ii).ToList();

        //    Console.WriteLine("Final Init");
        //    Console.ReadKey();

        //}


        private static HttpClient client = new HttpClient();

        public async static Task Algodon()
        {
            client.BaseAddress = new Uri("http://localhost:62046/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("services/Articles");

            if (response.IsSuccessStatusCode)
            {
                String res = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(res);

                var recList = obj.SelectTokens("ArticlesModel").ToList();

                List<Articles> listPlayers = JsonConvert.DeserializeObject<List<Articles>>(recList[0].ToString());
            }


        }


        //public static object MakeRequest(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType, Type JSONResponseType)
        //{

        //    try
        //    {
        //        HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
        //        string sb = JsonConvert.SerializeObject(JSONRequest);
        //        request.Method = JSONmethod;

        //        Byte[] bt = Encoding.UTF8.GetBytes(sb);

        //        Stream st = request.GetRequestStream();
        //        st.Write(bt, 0, bt.Length);
        //        st.Close();

        //        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        //        {

        //            if (response.StatusCode != HttpStatusCode.OK) throw new Exception(String.Format(
        //                "Server error (HTTP {0}: {1}).", response.StatusCode,
        //            response.StatusDescription));

        //            // DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));// object objResponse = JsonConvert.DeserializeObject();Stream stream1 = response.GetResponseStream();   
        //            StreamReader sr = new StreamReader(stream1);
        //            string strsb = sr.ReadToEnd();
        //            object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);

        //            return objResponse;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}

    }
}
