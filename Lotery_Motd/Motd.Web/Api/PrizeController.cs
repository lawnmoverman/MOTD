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

        /// <summary>
        ///  Get all prizes.
        /// </summary>       
        /// <returns>List of prizes </returns>
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
        /// <summary>
        ///   Gets single prize Prize object.
        /// </summary>
        /// <param name="id"> primary key. </param>
        /// <returns>Single PrizeViewModel object. </returns>
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
        /// <summary>
        ///   Add new prize.
        /// </summary>
        /// <param name="prize"> Prize view model. </param>        
        [HttpPost]
        public IHttpActionResult Post([FromBody]PrizeViewModel prize)
        {  
            if (!ModelState.IsValid)
            {
                return BadRequest("Prize object can not be added !");
            }
            else
            {
                service.AddNewPrize(prize);
                return Ok(prize);
            }          
            
        }

        // PUT: api/Prize/5
        /// <summary>
        /// Update Prize object.
        /// </summary>
        /// <param name="id"> primary key. </param>
        /// <param name="prize"> Prize view model. </param>        
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]PrizeViewModel prize)
        {    
            if (!ModelState.IsValid)
            {
                return BadRequest("Prize object can not be added !");
            }
            else
            {
                var _prize = service.EditPrize(prize);
                return Ok(prize);
            }
        }

        /// <summary>
        ///   Delete prize.
        /// </summary>
        /// <param name="id"> primary key. </param>       
        [HttpDelete]        
        public IHttpActionResult Delete(int id)
        {
            if(id >= 0)
            {
                service.DeletePrize(id);
                return Ok(id);
            }
            else
            {
                return BadRequest("Prize object can not be deleted !");
            }
           
        }
    }
}
