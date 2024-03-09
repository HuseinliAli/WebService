using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebService.Data.Contexts;
using WebService.Data.Seeds;
using WebService.Helpers;
using WebService.Requests.Accounts;
using WebService.Responses.Accounts;
using WebService.Responses.Commons;

namespace WebService.Services
{
    /// <summary>
    /// Summary description for AccountWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class AccountWebService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Register(UserForRegisterDto request)
        {
            byte[] hashedPasword = HashingHelper.CreatePasswordHash(request.Password);
            var user = new User()
            {
                Id=Guid.NewGuid(),
                FirstName=request.FirstName,
                LastName=request.LastName,
                EmailAddress=request.EmailAddress,
                Password=hashedPasword,
                Gender=request.Gender
            };
            using (var context = new ApplicationDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            var response = new UserForResponseDto() 
            { 
                Id=user.Id.ToString(),
                FullName=$"{user.FirstName} {user.LastName}", 
                EmailAddress=user.EmailAddress 
            };
            var jsonResult = JsonSerializer.Serialize<Response>(new DataResponse<UserForResponseDto>(response,Messages.SuccessOperation,true));
            return jsonResult;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Login(UserForLoginDto request)
        {
            using (var context = new ApplicationDbContext())
            {
                var jsonResult = String.Empty;
                var user = context.Users.FirstOrDefault(u => u.EmailAddress == request.EmailAddress);
                if(user == null || !HashingHelper.VerifyPasswordHash(request.Password, user.Password))
                {
                    jsonResult=JsonSerializer.Serialize<Response>(new Response(Messages.LoginFailed, false));
                    return jsonResult;
                }
                var userForResponse = new UserForResponseDto() 
                { 
                    Id=user.Id.ToString(), 
                    EmailAddress=user.EmailAddress, 
                    FullName=$"{user.FirstName} {user.LastName}" 
                };
                jsonResult = JsonSerializer.Serialize<DataResponse<UserForResponseDto>>(new DataResponse<UserForResponseDto>(userForResponse, Messages.SuccessOperation, true));
                return jsonResult;
            }
        }
    }
}
