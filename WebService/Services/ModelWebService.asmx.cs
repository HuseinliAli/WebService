using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for ModelWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ModelWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ModelsByBrandId(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var jsonResult = JsonSerializer.Serialize<List<Model>>(context.Models.Where(m => m.BrandId==id).ToList());
                return jsonResult;
            }

        }

  
  
        
    }
}
