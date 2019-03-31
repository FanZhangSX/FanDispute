using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FanDispute.WebAPI.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}