using FanDispute.WebAPI.Data;
using FanDispute.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FanDispute.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        private LoginEntity _entity;
        public LoginController()
        {
            _entity = new LoginEntity();
        }

        [Route("api/Login/Login"), HttpPost]
        public HttpResponseMessage Login([FromBody]LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"model is null");
            }
            if(model == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"model is null");
            }
            if (model.Email == null || model.Email == "")
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Email is null" );
            }
            var person = _entity.People.Where(x => x.Email == model.Email).FirstOrDefault();

            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"User {model.Email} does not exist!");
            }

            if (person.Password.Trim() != model.Password)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Password does not exist!");
            }

            if (person.TeamId != model.TeamId)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"User does not belong team {person.TeamId}!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, person);
        }
    }
}
