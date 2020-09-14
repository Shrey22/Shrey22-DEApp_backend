using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DEA.Models;

namespace DEA.Controllers
{
    public class StudentController : BaseController
    {
        deaEntities1 dalobj = new deaEntities1();
        Response response = new Response();

        StudentController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Student/{id:int}")]  
        public Response Get1(int id)                    // get student by id
        {
            T_User studtofind = dalobj.T_User.Find(id);

           try
            {
                if (studtofind != null)
                {
                    response.Status = "Record Found.";
                    response.Data = studtofind;
                    response.Err = null;

                    return response;
                }

                else
                {
                    response.Status = "Record NotFound.";
                    response.Data = null;
                    response.Err = null;

                    return response;
                }
            }

            catch(Exception ex)
            {
                response.Status = "Failed!";
                response.Data = null;
                response.Err = ex.InnerException;

                return response;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Studentclass/{no:int}")]
        public Response Get2(int no)                        // get students by class
        {
            var list = dalobj.T_User.ToList();

            try
            {
                if (list != null)
                {

                    var classstud = from s in list
                                    where s.Class == no
                                    select s;

                    if(classstud != null)
                    {
                        response.Status = "Record Found.";
                        response.Data = classstud;
                        response.Err = null;

                        return response;
                    }
                }

                else
                {
                    response.Status = "Record NotFound.";
                    response.Data = null;
                    response.Err = null;

                    return response;
                }
            }

            catch (Exception ex)
            {
                response.Status = "Failed!";
                response.Data = null;
                response.Err = ex.InnerException;
                
            }
            return response;
        }


    }
}
