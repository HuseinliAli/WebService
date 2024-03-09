using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for BrandWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BrandWebService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Brands()
        {
            List<Brand> brandList;
            using (var context = new ApplicationDbContext())
            {
                brandList = context.Brands.ToList();
            }
            string jsonResult = JsonSerializer.Serialize<List<Brand>>(brandList);
            return jsonResult;  
        }
    }
}
