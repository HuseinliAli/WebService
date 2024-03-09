using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Requests.Orders
{
    public class ParkingOrderStartDto
    {
        public string UserId { get; set; }
        public string CarId { get; set; }
        public int ParkingCenterId { get; set; }
    }

   
}