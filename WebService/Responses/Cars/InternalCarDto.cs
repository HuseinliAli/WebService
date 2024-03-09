using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Responses.Cars
{
    public class InternalCarDto
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string BrandModel{ get; set; }
        public string CarNumber { get; set; }
        public string TechNumber { get; set; }
    }
}