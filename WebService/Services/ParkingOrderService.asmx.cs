using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;
using WebService.Requests.Orders;
using WebService.Responses.Commons;
using WebService.Responses.ParkingCenters;
using WebService.Responses.ParkingOrders;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for ParkingOrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class ParkingOrderService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string StartOrder(ParkingOrderStartDto request)
        {       
            using (var context = new ApplicationDbContext())
            {
                var parkingOrder = new ParkingOrder()
                {
                    ParkingCenterId= request.ParkingCenterId,
                    UserId=Guid.Parse(request.UserId),
                    Id=Guid.NewGuid(),
                    CarId=Guid.Parse(request.CarId),
                    StartDate= DateTime.Now,
                };
                var parkingCenter = context.ParkingCenters.FirstOrDefault(pc => pc.Id==request.ParkingCenterId);
                var orders = context.ParkingOrders.Where(c => c.CarId.ToString()==request.CarId).ToList();
                
                if (parkingCenter.AvailableSlots>0 )
                {
                    if (orders.Any(x=>x.EndDate==DateTime.MinValue))
                    {
                        return JsonSerializer.Serialize<Response>(new Response(Messages.CarBusy, false));
                    }
                    context.ParkingOrders.Add(parkingOrder);
                    parkingCenter.AvailableSlots-=1;
                    context.SaveChanges();
                    return JsonSerializer.Serialize<Response>(new Response(Messages.SuccessOperation, true));
                }
                else
                {
                    return JsonSerializer.Serialize<Response>(new Response(Messages.OrderFailed, false));
                }   
            }   
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string EndOrder(string request)
        {
            using (var context = new ApplicationDbContext())
            {
                var order = context.ParkingOrders.FirstOrDefault(po => po.Id.ToString()==request);
                var center = context.ParkingCenters.FirstOrDefault(c => c.Id == order.ParkingCenterId);
                if(order !=null && center !=null)
                {
                    var totalPrice = CalculatePrice(center.PricePerHour, order.StartDate);
                    order.EndDate=DateTime.Now;
                    order.TotalPrice=totalPrice;
                    order.TotalPriceWithTax=totalPrice+(totalPrice*0.18m);
                    center.AvailableSlots++;
                    context.SaveChanges();
                    return JsonSerializer.Serialize<Response>(new Response(Messages.SuccessOperation, true));
                }
                else
                {
                    return JsonSerializer.Serialize<Response>(new Response(Messages.FailedOperation, false));
                }
            }
        }

        private decimal CalculatePrice(decimal hourlyRate,DateTime start)
        {
            decimal secondlyRate = hourlyRate/3600;
            TimeSpan difference = DateTime.Now - start;
            decimal seconds =(decimal)difference.TotalSeconds;
            return seconds*secondlyRate;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string History(string request)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = (from po in context.ParkingOrders
                              join car in context.InternalCars
                              on po.CarId equals car.Id
                              join center in context.ParkingCenters
                              on po.ParkingCenterId equals center.Id
                              select new ParkingOrderListDto()
                              {
                                  Id=po.Id.ToString(),
                                  CarNumber=car.CarNumber,
                                  ParkingCenterName=center.Name,
                                  StartDate=po.StartDate,
                                  EndDate=po.EndDate,
                                  TotalPrice=po.TotalPrice,
                                  TotalPriceWithTax=po.TotalPriceWithTax
                              }).ToList();
                var jsonResult = JsonSerializer.Serialize<List<ParkingOrderListDto>>(result);
                return jsonResult;
            }
        }
    }
}
