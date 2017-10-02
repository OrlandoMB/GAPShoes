using GAP.WebApi.Application.Stores;
using GAP.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace GAP.WebApi.Controllers.Stores
{
    [BasicAuthentication]
    public class StoresController : ApiController
    {
        StoreApplication _storeApp = new StoreApplication();

        // GET api/values
        [HttpGet]
        public IHttpActionResult Get()
        {
            var _allStores = _storeApp.GetAllStores();

            return Ok(
                new {
                    stores = _allStores,
                    success = "true",
                    total_elements = _allStores.Count()
                });
        }

        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var _store = _storeApp.GetStore(id);

            return Ok(
                new
                {
                    stores = _store,
                    success = "true",
                    total_elements = 1
                });
        }
      
    }
}
