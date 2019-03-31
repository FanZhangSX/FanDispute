using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using FanDispute.WebAPI.Data;

namespace FanDispute.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TeamController : ApiController
    {
        private LoginEntity _entity;

        public TeamController()
        {
            _entity = new LoginEntity();
        }
        // GET: api/Team
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, 
                _entity.Teams.Select(x=> new { Id = x.Id, Name=x.Name}));
        }

        // GET: api/Team/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Team
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Team/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Team/5
        public void Delete(int id)
        {
        }
    }
}
