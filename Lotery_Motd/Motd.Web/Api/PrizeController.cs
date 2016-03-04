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


        IPrizeService service = new PrizeService();

        // GET: api/Prize
        [HttpGet]
        [Route("GetAllPrizes")]
        public IHttpActionResult Get()
        {
            List<PrizeViewModel> prizeList = service.GetPrizes();
            if (prizeList == null)
            {
                return NotFound();
            }
            return Ok(prizeList);
        }


        // GET: api/Prize/5
        [HttpGet]
        [Route("GetPrize/{id}")]
        public IHttpActionResult Get(int id)
        {
            List<PrizeViewModel> prizeList = service.GetPrizes();
            PrizeViewModel prize = prizeList.Find(p => p.Id == id);
            if (prizeList == null)
            {
                return NotFound();
            }
            return Ok(prize);
        }

        // POST: api/Prize
        [HttpPost]
        public void Post([FromBody]PrizeViewModel value)
        {
            service.AddNewPrize(value);
        }

        // PUT: api/Prize/5
        [HttpPut]
        public void Put(int id, [FromBody]PrizeViewModel value)
        {
            service.EditPrize(value);
        }

        /// <summary>  
        /// Delete prize from list.  
        /// </summary>  
        /// <param name="Uid">int id</param>  
        /// <returns></returns> 
        [HttpDelete]        
        public void Delete(int id)
        {
            service.DeletePrize(id);
        }
    }
}
