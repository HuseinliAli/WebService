using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;
using WebService.Requests.Cars;
using WebService.Responses.Cars;
using WebService.Responses.Commons;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for CarWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class CarWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InternalCarAdd(InternalCarAddDto request)
        {
     
            var car = new InternalCar() {Id=Guid.NewGuid(), UserId=Guid.Parse(request.UserId), ModelId=request.ModelId,CarNumber=request.CarNumber,TechpassportSerialNumber=request.TechNumber};
            using (var context = new ApplicationDbContext())
            {
                var findedCar = context.InternalCars.FirstOrDefault(c => c.CarNumber ==request.CarNumber ||c.TechpassportSerialNumber==request.TechNumber);
                if (findedCar!=null)
                {
                    return JsonSerializer.Serialize<Response>(new Response(Messages.CarExists, false));
                }
                context.InternalCars.Add(car);
                context.SaveChanges();
            }

            return JsonSerializer.Serialize<Response>(new Response(Messages.SuccessOperation, true));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InternalCarsByUserId(string request)
        {
            var list = new List<InternalCarDto>();
            using (var context = new ApplicationDbContext())
            {
                list = (from car in context.InternalCars
                              join model in context.Models on car.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new InternalCarDto
                              {
                                  UserId = car.UserId.ToString(),
                                  Id = car.Id.ToString(),  
                                  BrandModel = brand.Name+" "+ model.Name,
                                  CarNumber = car.CarNumber,
                                  TechNumber = car.TechpassportSerialNumber
                              }).Where(u=>u.UserId == request).ToList();

            }
            string jsonResult = JsonSerializer.Serialize<List<InternalCarDto>>(list);
            return jsonResult;
        }
    }
}
