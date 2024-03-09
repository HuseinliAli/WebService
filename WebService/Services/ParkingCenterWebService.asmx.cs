using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;
using WebService.Responses.ParkingCenters;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for ParkingCenterWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class ParkingCenterWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ParkingCenters()
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.ParkingCenters
                    .Select(pc => new ParkingCenterListDto() 
                    { 
                        Id=pc.Id, 
                        Latitude=pc.Latitude, 
                        Longitude=pc.Longitude, 
                        Name=pc.Name,
                        AvailableSlots=pc.AvailableSlots,
                        PricePerHour=pc.PricePerHour,
                        TotalSlots=pc.TotalSlots }).ToList();
                var jsonResult=JsonSerializer.Serialize<List<ParkingCenterListDto>>(result);
                return jsonResult;
            } 
        }
    }
}
