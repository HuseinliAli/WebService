using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Responses.Accounts
{
    public class UserForResponseDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}