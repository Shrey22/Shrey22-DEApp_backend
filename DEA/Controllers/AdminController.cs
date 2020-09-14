using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DEA.Models;

namespace DEA.Controllers
{
    public class AdminController : BaseController
    {
        deaEntities1 dalobj = new deaEntities1();
        Response response = new Response();
        

        AdminController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/allrecords")]
        public Response Get() //all records
        {
            List<T_User> list = dalobj.T_User.ToList();

            if(list!=null)
            {
                response.Data = list;
                response.Status = "Records Found.";
                response.Err = null;

                return response;
            }

            else
            {
                response.Data = list;
                response.Status = "Records Not Found.";
                response.Err = null;

                return response;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/onlystudents")]
        public Response Get1() //only students records
        {
            List<T_User> list = dalobj.T_User.ToList();

            if (list != null)
            {

                var stud = from s in list
                           where s.Role_id == 2
                           select s;

                response.Data = stud;
                response.Status = "Records Found.";
                response.Err = null;

                return response;
            }

            else
            {
                response.Data = null;
                response.Status = "Records Not Found.";
                response.Err = null;

                return response;
            }
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/byname")]
        public Response Post2([FromBody] T_User data)                //get student record by name
        {
            if (data != null)
            {
                List<T_User> list = dalobj.T_User.ToList();

                if (list != null)
                {

                    var stud = (from s in list
                                where s.Name == data.Name
                                select s).ToList();

                    if (stud.Count != 0)
                    {
                        response.Data = stud;
                        response.Status = "Records Found.";
                        response.Err = null;

                        return response;
                    }
                    else
                    {
                        response.Data = stud;
                        response.Status = "No Matching Records Found!";
                        response.Err = null;

                        return response;
                    }
                }

                else
                {
                    response.Data = null;
                    response.Status = "Records Not Found.";
                    response.Err = null;

                    return response;
                }
            }
            else
            {
                response.Data = null;
                response.Status = "Records Not Found. data recived as null";
                response.Err = null;

                return response;
            }
        }

       

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/addnew")]
        public Response Post1([FromBody] T_User data)  // add student record
        {
            if(data != null)
            {
                var added = dalobj.T_User.Add(data);

                try
                {
                    dalobj.SaveChanges();

                    response.Data = added;
                    response.Status = "Record successfully added...";
                    response.Err = null;

                    return response;
                }

                catch(Exception ex)
                {
                    response.Status = "Failed!";
                    response.Err = ex.InnerException;

                    return response;
                }
            }

            else
            {
                response.Data = null;
                response.Status = "Empty Fields";
                response.Err = null;

                return response;
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/updaterecord/{id:int}")]
        public Response Put1(int id, [FromBody] T_User data)  //update student record using userid
        {
            if(data!=null)
            {
                T_User findentry = dalobj.T_User.Find(id);

                try
                {
                    if (findentry != null)
                    {
                        if(data.Name!=null)
                             findentry.Name = data.Name;
                        if(data.Gender!=null)
                             findentry.Gender = data.Gender;
                        if (data.DOB != null)
                            findentry.DOB = data.DOB;
                        if (data.Email != null)
                            findentry.Email = data.Email;
                        if (data.Password != null)
                            findentry.Password = data.Password;
                        if (data.MobileNo != null)
                            findentry.MobileNo = data.MobileNo;
                        if (data.Class != null)
                            findentry.Class = data.Class;
                        if (data.Street != null)
                            findentry.Street = data.Street;
                        if (data.City != null)
                            findentry.City = data.City;
                        if (data.State != null)
                            findentry.State = data.State;
                        if (data.Country != null)
                            findentry.Country = data.Country;
                        if (data.PostalCode != null)
                            findentry.PostalCode = data.PostalCode;
                        if (data.IsOnline != false)
                            findentry.IsOnline = data.IsOnline;
                        if (data.IsLocked != false)
                            findentry.IsLocked = data.IsLocked;
                        if (data.Role_id != null)
                            findentry.Role_id = data.Role_id;

                        dalobj.SaveChanges();

                        response.Status = "Record successfully updated.";
                        response.Err = null;
                        response.Data = null;

                        return response;
                    }
                }

                catch(Exception ex)
                {
                    response.Status = "Failed!";
                    response.Err = ex.InnerException;
                    response.Data = null;

                    return response;
                }
            }
            else
            {
                response.Data = null;
                response.Status = "Empty Fields";
                response.Err = null;
            }
            return response;
        }

    }
}
