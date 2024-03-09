using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Responses.ParkingCenters
{
    public class ParkingCenterListDto
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public short AvailableSlots { get; set; }
        public short TotalSlots { get; set; }
    }
}