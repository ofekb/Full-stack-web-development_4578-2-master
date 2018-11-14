# N-Tier model (web api)

* `DB` (local db)
![picture](step1.png)
Tiers:
* `DAL`
    * refernces to: `DB`
* BOL
* BLL
    * refernces to: `DAL` , `BOL`
* UIL
    * refernces to: `BLL` , `BOL`

# Code of each tier

### DAL
```csharp
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _00_DAL
{
    public static class DBAccess
    {
        static SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seldat\Desktop\02_NTiers\DB\Database.mdf;Integrated Security=True");

        public static int? RunNonQuery(string query)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

        public static object RunScalar(string query)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                return command.ExecuteScalar();
            }
            catch(Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
            
        }

        public static List<T> RunReader<T>(string query, Func<SqlDataReader, List<T>> func)
        {
            try
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                return func(reader);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

    }
}
```


### BOL
```csharp
using _02_BOL.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_BOL
{
    public class User
    {

        public int Id { get; set; }

        //4- 12 chars
        //requierd
        [Required]
        [MinLength(4), MaxLength(12)]
        public string UserName { get; set; }

        //default is true
        [DefaultValue(true)]
        public bool IsMale { get; set; }

        //If user is male - min value is 18
        //If user is women - min value is 20
        //For both - max is 120
        [RangeAge]
        public int Age { get; set; }

    }
}

```
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _02_BOL.Validations
{
    public class RangeAgeAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("IsMale");
            object propertyValue = property.GetValue(instance);
            Boolean.TryParse(propertyValue.ToString(), out bool isMale);

            return ((isMale && (int)value >= 18 || (int)value >= 20) && (int)value <= 120) ? null :
                new ValidationResult("Min age:" + (isMale ? 18 : 20) + ", Max age: 120");
        }
    }
}
```

### BLL
```csharp
using _00_DAL;
using _01_BOL;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _02_BLL
{
    public static class LogicManager
    {

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM [dbo].[Users]";

            Func<SqlDataReader, List<User>> func = (reader)=>{
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id =reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        IsMale = reader.GetBoolean(3),
                        Age = reader.GetInt32(2)
                    });
                }
                return users;
             };

            return DBAccess.RunReader(query, func);
        }

        public static string GetUserName(int id)
        {
            string query = $"SELECT Name FROM [dbo].[Users] WHERE Id={id}";
            return DBAccess.RunScalar(query).ToString();
        }

        public static bool RemoveUser(int id)
        {
            string query = $"DELETE FROM [dbo].[Users] WHERE Id={id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool UpdateUser(User user)
        {
            string query = $"UPDATE [dbo].[Users] SET Name='{user.UserName}', Age={user.Age}  WHERE Id={user.Id}";
            return DBAccess.RunNonQuery(query) == 1;
        }

        public static bool AddUser(User user)
        {
            string query = $"INSERT INTO [dbo].[Users] VALUES ('{user.UserName}',{user.Age},{Convert.ToByte(user.IsMale)})";
            return DBAccess.RunNonQuery(query) == 1;
        }
    }
}
```


### UIL
```csharp
using _01_BOL;
using _02_BLL;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace _03_uil.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<User>>(LogicManager.GetAllUsers(), new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Users/5
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<String>(LogicManager.GetUserName(id), new JsonMediaTypeFormatter())
            };
        }

        // POST: api/Users
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                return (LogicManager.AddUser(value)) ?
                   new HttpResponseMessage(HttpStatusCode.Created) :
                   new HttpResponseMessage(HttpStatusCode.BadRequest)
                   {
                       Content = new ObjectContent<String>("Can not add to DB", new JsonMediaTypeFormatter())
                   };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };

        }

        // PUT: api/Users/5
        public HttpResponseMessage Put([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return (LogicManager.UpdateUser(value)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not update in DB", new JsonMediaTypeFormatter())
                    };
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<List<string>>(ErrorList, new JsonMediaTypeFormatter())
            };
        }

        // DELETE: api/Users/5
        public HttpResponseMessage Delete(int id)
        {
            return (LogicManager.RemoveUser(id)) ?
                    new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new ObjectContent<String>("Can not remove from DB", new JsonMediaTypeFormatter())
                    };
        }
    }
}

```


# Test api with `curl`

### Get Request
```
curl -X GET -v http://localhost:60762/api/users
```

```
> GET /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:30:15 GMT
< Content-Length: 60
<
[{"Id":1,"UserName":"Test","IsMale":false,"Age":22}]
```

### Post Request (not valid data)
```
curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"Test2\", \"Age\":\"13\",\"IsMale\":\"True\"}"  http://localhost:60762/api/users
```

```
* Connected to localhost (::1) port 60762 (#0)
> POST /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 48
>
* upload completely sent off: 48 out of 48 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:32:48 GMT
< Content-Length: 28
<
["Min age:18, Max age: 120"]
```

### Post Request (not valid data)

```
curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"Test2\", \"Age\":\"18\",\"IsMale\":\"False\"}"  http://localhost:60762/api/users
```
```
> POST /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 46
>
* upload completely sent off: 46 out of 46 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:33:21 GMT
< Content-Length: 141
<
["Min age:20, Max age: 120"]

```

### Post Request (valid data - ADDED NEW USER)

```
curl -v -X POST -H "Content-type: application/json" -d "{\"UserName\":\"Test2\", \"Age\":\"18\",\"IsMale\":\"True\"}"  http://localhost:60762/api/users
```
```
> POST /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 48
>
* upload completely sent off: 48 out of 48 bytes
< HTTP/1.1 201 Created
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:35:38 GMT
< Content-Length: 0
```


### Get Request (will return also the new user)
```
curl -X GET -v http://localhost:60762/api/users
```
```
> GET /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:36:33 GMT
< Content-Length: 118
<
[{"Id":1,"UserName":"Test","IsMale":false,"Age":22},{"Id":2,"UserName":"Test2","IsMale":true,"Age":18}]
```


### Put Request (not valid data)
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"2\", \"UserName\":\"Test3\", \"Age\":\"17\",\"IsMale\":\"False\"}"  http://localhost:60762/api/users
```

```
> PUT /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 59
>
* upload completely sent off: 59 out of 59 bytes
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:39:35 GMT
< Content-Length: 28
<
["Min age:20, Max age: 120"]
```

### Put Request (valid data - EDITED USER)
```
curl -v -X PUT -H "Content-type: application/json" -d "{\"Id\":\"2\", \"UserName\":\"Test3\", \"Age\":\"30\",\"IsMale\":\"False\"}"  http://localhost:60762/api/users
```

```
> PUT /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
> Content-type: application/json
> Content-Length: 59
>
* upload completely sent off: 59 out of 59 bytes
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:40:42 GMT
< Content-Length: 0
```



### Get Request (will return also the edited user)

```
curl -X GET -v http://localhost:60762/api/users
```

```
> GET /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-SourceFiles: =?UTF-8?B?QzpcVXNlcnNcc2VsZGF0XERlc2t0b3BcMDJfTlRpZXJzXDAzX3VpbFxhcGlcdXNlcnM=?=
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:41:14 GMT
< Content-Length: 118
<
[{"Id":1,"UserName":"Test","IsMale":false,"Age":22},{"Id":2,"UserName":"Test3","IsMale":true,"Age":30}]
```



### Delete Request (not valid id)
```
curl -X DELETE -v http://localhost:60762/api/users?id=3
```

```
> DELETE /api/users?id=3 HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 400 Bad Request
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:44:38 GMT
< Content-Length: 24
<
"Can not remove from DB"
```
### Delete Request (valid id - REMOVED USER)

```
curl -X DELETE -v http://localhost:60762/api/users?id=1
```
```
> DELETE /api/users?id=1 HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:45:23 GMT
< Content-Length: 0
```

### Get Request (will not return the removed user)
```
curl -X GET -v http://localhost:60762/api/users
```
```
> GET /api/users HTTP/1.1
> Host: localhost:60762
> User-Agent: curl/7.61.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Cache-Control: no-cache
< Pragma: no-cache
< Content-Type: application/json; charset=utf-8
< Expires: -1
< Server: Microsoft-IIS/10.0
< X-AspNet-Version: 4.0.30319
< X-Powered-By: ASP.NET
< Date: Mon, 15 Oct 2018 06:46:22 GMT
< Content-Length: 59
<
[{"Id":2,"UserName":"Test3","IsMale":true,"Age":30}]

```
