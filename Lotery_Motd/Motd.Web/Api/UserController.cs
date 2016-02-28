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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        IUserService service = new UserService();

        // GET: api/User
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult Get()
        {
            List<UserViewModel> userList = service.GetUsers();
            if(userList == null)
            {
                return NotFound();
            }
            return Ok(userList);
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
