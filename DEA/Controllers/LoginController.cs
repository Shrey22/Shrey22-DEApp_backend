using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DEA.Models;

namespace DEA.Controllers
{
    public class LoginController : BaseController
    {
        deaEntities1 dalobj = new deaEntities1();

        Response response = new Response();

        LoginController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        public Response Post([FromBody] T_User data)
        {
            List<T_User> user = dalobj.T_User.ToList();

            if ((data.Email != null && data.Password != null))
            {


                var validUser = (from u in user
                                 where u.Email == data.Email && u.Password == data.Password
                                 select u).SingleOrDefault();
                if (validUser != null)
                {
                    response.Status = "success";
                    response.Err = null;
                    response.Data = validUser;
                    //   logger.Log("Login Successfull.");
                }
                else
                {
                    response.Status = "failed! Invalid Credentials";
                    response.Err = null;
                    response.Data = null;
                    //     logger.Log("Login Failed!");
                }

                return response;

            }
            else
            {
                response.Status = "Plz enter Credentials";
                response.Err = null;
                return response;
            }

        }

    }
}
