using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FanDispute.WebAPI.Models
{
    [DataContract]
    public class LoginModel
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int TeamId { get; set; }
    }
}