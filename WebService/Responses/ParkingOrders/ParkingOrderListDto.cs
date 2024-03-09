using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Responses.ParkingOrders
{
    public class ParkingOrderListDto
    {
        public string Id { get; set; }
        public string CarNumber { get; set; }
        public string ParkingCenterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
    }
}