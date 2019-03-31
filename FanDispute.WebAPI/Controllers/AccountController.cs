using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FanDispute.WebAPI.Models;
using System.Web.Http.Cors;
using FanDispute.WebAPI.Data;

namespace FanDispute.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AccountController : ApiController
    {
        private LoginEntity _entity;

        public AccountController()
        {
            _entity = new LoginEntity();
        }

        List<AccountModel> models = new List<AccountModel>
        {
            new AccountModel {ID=1, FirstName="Fan", LastName="Zhang", Email="Fan.Zhang.Sx@gmail.com"},
            new AccountModel {ID=2, FirstName="Fan2", LastName="Zhang", Email="Fan.Zhang.1@gmail.com"},
            new AccountModel {ID=3, FirstName="Fan3", LastName="Zhang", Email="Fan.Zhang.2@gmail.com"},
            new AccountModel {ID=4, FirstName="Fan4", LastName="Zhang", Email="Fan.Zhang.3@gmail.com"},
        };

        // GET: api/Account
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, models);
            //return Ok(models.ToList());
        }

        // GET: api/Account/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, models.Where(x => x.ID == id).First());
            //return Ok(models.Where(x=>x.ID==id).First());
        }

        // POST: api/Account
        public HttpResponseMessage Post([FromBody]AccountModel model)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invaild input");
            }
            if(model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invaild input");
            }

            models.Add(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
