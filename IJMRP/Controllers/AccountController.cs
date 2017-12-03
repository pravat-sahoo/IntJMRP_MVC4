using IJMRP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IJMRP.Controllers
{
    public class AccountController : Controller
    {
        MyRoleProvider rlob = new MyRoleProvider();
        dbintjmrpEntities db = new dbintjmrpEntities();

        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginInputModel logob, string ReturnUrl = " ")
        {

            try
            {

                //string username1 = User.Identity.Name;
                //Session.Clear();
                //FormsAuthentication.SignOut();
                //  HttpContext.Cache.Remove();
                //Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);
                //string username2 = User.Identity.Name;


                //Session["username"] = logob.UserName;
                //Session["Password"] = logob.Password;
                if (logob.UserName == null)
                {
                    ViewBag.Unull = "!!!Enter User Id ";
                }
                if (logob.Password == null)
                {
                    ViewBag.Pnull = "!!!Enter Password";
                }
                if (ModelState.IsValid)
                {

                    //formaut
                    //Session["username"] = logob.UserName;
                    //Session["Password"] = logob.Password;
                    FormsAuthentication.SetAuthCookie(logob.UserName, false);
                    var isValidUser = Membership.ValidateUser(logob.UserName, logob.Password);
                    //string username3 = User.Identity.Name;

                    //r iss=Membership.FindUsersByName()
                    if (isValidUser)
                    {
                        //for (int i = 0; i < 3; i++)
                        //{
                        //HttpContext.User = new GenericPrincipal(new GenericIdentity(logob.UserName), null);
                        var role = rlob.GetRolesForUser(logob.UserName);
                        HttpContext.User = new GenericPrincipal(new GenericIdentity(logob.UserName), role);
                        if (User.Identity.IsAuthenticated)
                        {
                            //if (Url.IsLocalUrl(ReturnUrl))
                            //{
                            //    return Redirect(ReturnUrl);

                            //}
                            //else
                            //{
                            //ClassFY obfy = new ClassFY();

                            //ClassFY.Financeal_Year = obfy.getFYID(DateTime.Today);
                           // string username = User.Identity.Name;

                            return RedirectToAction("EditeHomePage","Admin");
                            //var l = (from U in db.tblUserLogins where U.U_USERID == username select U.U_EMAIL_ADDRESS).First();

                           // var user = db.tblUserLogins.Where(c => c.U_USERID == username).SingleOrDefault();

                            // Session["LoginUserNAme"] = user.U_EMAIL_ADDRESS.ToString();
                            //////if (user.U_TYPE.ToString() != null)
                            //////{
                            //////    Session["UserType"] = user.U_TYPE.ToString();
                            //////    return RedirectToAction("MainIndex");
                            //////}
                            //////else
                            //////{
                            //////    Session.Clear();
                            //////    FormsAuthentication.SignOut();
                            //////}

                            // break;
                            // return RedirectToAction("RedirectToDefault");
                            //}
                        }
                        else
                        {


                        }
                        //}


                    }

                }
                ViewBag.LERROR = "User Id or Password Not Valid";
                ModelState.AddModelError(string.Empty, "!!!User Id or Password Not Valid");
                //ModelState.Clear();
                // return RedirectToAction("Login");
                //Session.Clear();
                // FormsAuthentication.SignOut();
                // return View("Login");
            }
            catch
            {
                Session.Clear();
                FormsAuthentication.SignOut();
            }
            return View("Login");
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            //HttpContext.User = new GenericPrincipal(new GenericIdentity(null), null);
            return Redirect("Login");
        }
        public ActionResult ErrorOccured()
        {
            return View("Error");
        }
        public ActionResult Error404Occured()
        {
            return View("404");
        }
        public ActionResult Error500Occured()
        {
            return View("500");
        }

    }
}
