using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Requests.Cars
{
    public class InternalCarAddDto
    {
        public string UserId { get; set; }
        public int ModelId { get; set; }
        public string CarNumber { get; set; }
        public string TechNumber { get; set; }
    }
}