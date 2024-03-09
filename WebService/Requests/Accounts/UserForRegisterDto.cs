using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Requests.Accounts
{
    public class UserForRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}