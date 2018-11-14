using _01_custom_validation.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace _01_custom_validation.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(GlobalData.Users, new JsonMediaTypeFormatter())
            };
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                GlobalData.Users.Add(value);
                return new HttpResponseMessage(HttpStatusCode.Created);
            };

            List<string> ErrorList = new List<string> ();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }
    }
}
