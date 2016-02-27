using Motd.Services;
using Motd.Services.Contracts;
using Motd.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Motd.Web.Api
{
    [RoutePrefix("api/Prize")]
    public class PrizeController : ApiController
    {


        IPrizeService servis = new PrizeService();

        // GET: api/Prize
        [HttpGet]
        [Route("GetAllPrizes")]
        public IHttpActionResult Get()
        {
           
            List<PrizeViewModel> lista = servis.GetPrizes();
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        // GET: api/Prize/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prize
        [HttpPost]
        public void Post([FromBody]PrizeViewModel value)
        {
            servis.AddNewPrize(value);
        }

        // PUT: api/Prize/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prize/5
        public void Delete(int id)
        {
        }
    }
}
