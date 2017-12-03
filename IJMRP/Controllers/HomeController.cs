using IJMRP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IJMRP.Controllers
{
    public class HomeController : Controller
    {
        //
        dbintjmrpEntities db = new dbintjmrpEntities();

        // GET: /Home/
        public ActionResult Subscription()
        {

            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "Subscription").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.Subscription = html;

            return View();
        }
        public ActionResult Index()
        {
           
               var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "ABOUT_US").Select(x => x.WEB_DESC).FirstOrDefault()));
              ViewBag.Aboutus =html;

            return View();
        }
        public ActionResult About_journal()
        {

            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "About_the_Journal").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.About_the_Journal = html;

            return View();
        }
        public ActionResult Succes_Email()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContuctUS()
        {
           // TempData["emailsuccess"] = "success";

            return View();
        }
        [HttpPost]
        public ActionResult ContuctUS(IJMRP.Models.EmailClass objModelMail)
        {

            
            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBMIT_MANUALSCRIPT").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.Sub_Manual = html;
            try
            {
                if (ModelState.IsValid)
                {

                string msg_end = "<br/> <br/>Thanks and Regards,<br/>"+objModelMail.name+"<br/>"+objModelMail.sender;

                MailMessage mail = new MailMessage();
                string toadd = "editorial@intjmrp.com";
                mail.Subject = objModelMail.Subject;
                mail.Body = objModelMail.Body + msg_end;


                //if (fileUploader != null)
                //{
                //    string fileName = Path.GetFileName(fileUploader.FileName);
                //    mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                //}
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    mail.From = new MailAddress("info@intjmrp.com");

                    mail.To.Add(toadd);
                    smtp.EnableSsl = false;
                    NetworkCredential networkCredential = new NetworkCredential("info@intjmrp.com", "intjmrp@123#");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 25;
                    smtp.Host = "intjmrp.com";
                   
                        TempData["emailsuccess"] = "success";

                        smtp.Send(mail);
                        smtp.Dispose();
                       // return RedirectToAction("Succes_Email");

                   


                }
                }
            }
            catch(Exception ex)
            {
                ViewBag.EnterError = ex.Message;

            }
            IJMRP.Models.EmailClass ob = new EmailClass();
            ob.name = null;
            ob.Body = null;
            ob.sender = null;
            ob.Subject = null;
            return View("ContuctUS", ob);



        }

         
        public ActionResult Guide_Author()
        {
            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "GUIDE_FOR_AUTHORS").Select(x => x.WEB_DESC).FirstOrDefault()));
              ViewBag.Guide_For_Author =html;

              return View();
        }

        public ActionResult About_Publisher()
        {
            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "ABOUT_PUBLISHER").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.About_Pub = html;

            return View();
        }


        public ActionResult Editorial_Team()
        {
            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "EDITORIAL_TEAM").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.EITORIAL_TEAM = html;
            return View();
        }
       
        public ActionResult Archive()
        {
            var l = db.tblArchives.OrderByDescending(c => c.ARCHIVE_YEAR).ToList();

            return View("Archive",l);
        }
        public ActionResult Currentissue_Archive(string bid)
        {
            //var l = db.tblArchives.OrderByDescending(c => c.ARCHIVE_YEAR).ToList();
            var current_Archive = (db.tblArchives.OrderByDescending(x => x.ARCHIVE_YEAR).Take(1).Select(x => x.ARCHIVE_DETAILS)).FirstOrDefault();
            ViewBag.CurentArchive = bid;
            return View("Current_Issue");
        }
        [HttpGet]
        public ActionResult Joinus()
        {
            //var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBMIT_MANUALSCRIPT").Select(x => x.WEB_DESC).FirstOrDefault()));
            //ViewBag.Sub_Manual = html;
            
            return View();
        }
        [HttpPost]
        public ActionResult Joinus(IJMRP.Models.ClassJoinUs objModelMail, HttpPostedFileBase fileUploader)
        {
            //var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBMIT_MANUALSCRIPT").Select(x => x.WEB_DESC).FirstOrDefault()));
            //ViewBag.Sub_Manual = html;
            string msg_end = "<br/> <br/>Thanks and Regards,<br/>" + objModelMail.Name + "<br/>" + objModelMail.Email;

            try
            {
                if (ModelState.IsValid)
                {
                    string FullFileName = string.Empty;
                    int i = 0;
                    string[] paths = new string[2];

                    //multiple file upload
                    foreach (string FileUpload in Request.Files)
                    {
                        // HttpPostedFileBase fileUploader =  FileUpload;"~/Content/ReportsFile/" +
                        if (Request.Files[FileUpload].ContentLength == 0)
                        {
                            i++;
                            continue;
                        }
                        //int fileLengthInKB = Request.Files[FileUpload].ContentLength / 2048;
                        //if (fileLengthInKB <= 2048)
                        //{
                        string fileName = Guid.NewGuid() + Path.GetExtension(Request.Files[FileUpload].FileName);
                        //Request.Files[FileUpload].SaveAs(Path.Combine(Server.MapPath("~/Content/ReportsFile/"), fileName));
                        FullFileName = fileName;
                        paths[i] = FullFileName;
                        //}
                    }
                    MailMessage mail = new MailMessage();
                    string toadd = "editorial@intjmrp.com";
                    mail.Subject = "Resume For Joinig in Team";
                    mail.Body = "Type:" + objModelMail.Type + "<br/>Name:" + objModelMail.Name + "<br/>Department:" + objModelMail.Department + "<br/>Academic Position:" + objModelMail.Academic_Position + "<br/>Institution Affliation Address:" + objModelMail.Institution_Affliation_Address + "<br/>Publications:" + objModelMail.Publications + "<br/>City:" + objModelMail.City + "<br/>Country:" + objModelMail.Country + "<br/>Phone" + objModelMail.Phone + "<br/>Postal Code" + objModelMail.Postal_Code;


                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        mail.From = new MailAddress("info@intjmrp.com");

                        mail.To.Add(toadd);
                        smtp.EnableSsl = false;
                        NetworkCredential networkCredential = new NetworkCredential("info@intjmrp.com", "intjmrp@123#");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 25;
                        smtp.Host = "intjmrp.com";
                        try
                        {
                            smtp.Send(mail);
                            ViewBag.emailsuccess = "success";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);   //Should print stacktrace + details of inner exception

                            if (ex.InnerException != null)
                            {
                                Console.WriteLine("InnerException is: {0}", ex.InnerException);
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.EnterError = ex.Message;

            }
            if (ViewBag.emailsuccess != null)
            {
                return RedirectToAction("Succes_Email");
            }
            return View();

        }
        //public ActionResult Subscription()
        //{

        //    var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBSCRIPTION").Select(x => x.WEB_DESC).FirstOrDefault()));
        //    ViewBag.Subscription = html;
        //    return View();


        //}
        [HttpGet]
        public ActionResult Submit_Manuscripts()
        {

            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBMIT_MANUALSCRIPT").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.Sub_Manual = html;
            return View();


        }
        
        [HttpPost]
        public ActionResult Submit_Manuscripts(IJMRP.Models.EmailClass objModelMail, HttpPostedFileBase fileUploader)
        {
            var html = new MvcHtmlString((db.tblWebtexts.Where(x => x.WEB_ID == "SUBMIT_MANUALSCRIPT").Select(x => x.WEB_DESC).FirstOrDefault()));
            ViewBag.Sub_Manual = html;
            string msg_end = "<br/> <br/>Thanks and Regards,<br/>" + objModelMail.name + "<br/>" + objModelMail.sender;

            try
            {
                if (ModelState.IsValid)
                {
                    string FullFileName = string.Empty;
                                    int i = 0;
                                    string[] paths = new string[2];

                    //multiple file upload
                    foreach (string FileUpload in Request.Files)
                    {
                        // HttpPostedFileBase fileUploader =  FileUpload;"~/Content/ReportsFile/" +
                        if (Request.Files[FileUpload].ContentLength == 0)
                        {
                            i++;
                            continue;
                        }
                        //int fileLengthInKB = Request.Files[FileUpload].ContentLength / 2048;
                        //if (fileLengthInKB <= 2048)
                        //{
                            string fileName = Guid.NewGuid() + Path.GetExtension(Request.Files[FileUpload].FileName);
                            //Request.Files[FileUpload].SaveAs(Path.Combine(Server.MapPath("~/Content/ReportsFile/"), fileName));
                            FullFileName =  fileName;
                            paths[i] = FullFileName;
                        //}
                         }
                    MailMessage mail = new MailMessage();
                    string toadd = "submission@intjmrp.com";
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body + msg_end;


                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        mail.From = new MailAddress("info@intjmrp.com");

                        mail.To.Add(toadd);
                        smtp.EnableSsl = false;
                        NetworkCredential networkCredential = new NetworkCredential("info@intjmrp.com", "intjmrp@123#");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 25;
                        smtp.Host = "intjmrp.com";
                        try
                        {
                            smtp.Send(mail);
                            ViewBag.emailsuccess = "success";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);   //Should print stacktrace + details of inner exception

                            if (ex.InnerException != null)
                            {
                                Console.WriteLine("InnerException is: {0}", ex.InnerException);
                            }
                        }


                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.EnterError = ex.Message;

            }
            if (ViewBag.emailsuccess!=null)
            {
                return RedirectToAction("Succes_Email");
            }
            return View();

        }
        public JsonResult loadci()
        {

            var current_Archive = (db.tblArchives.OrderByDescending(x => x.ARCHIVE_YEAR).Take(1).Select(x => x.ARCHIVE_DETAILS)).FirstOrDefault();
            var cur_issue = (from ci in db.tblCurrentIssues
                             where ci.CURENTISSUE_ARCHIVE_ID == current_Archive
                             select new
                             {
                                 ci.CURENTISSUE_ID,
                                 ci.CURENTISSUE_NAME,
                                 ci.CURENTISSUE_GROUP,
                                 ci.CURENTISSUE_DATE,
                                 ci.CURENTISSUE_AUTHOR,
                                 ci.CURENTISSUE_ARCHIVE_ID,
                                 // ci.CURENTISSUE_ABSTRACT,
                                 ci.CURENTISSUE_FILEPATH
                             }).ToList();
            return Json(cur_issue,JsonRequestBehavior.AllowGet);
    
        }

        public JsonResult loaAbstract(int id)
        {

            var current_Archive = (db.tblArchives.OrderByDescending(x => x.ARCHIVE_YEAR).Take(1).Select(x => x.ARCHIVE_DETAILS)).FirstOrDefault();
            var cur_issue = (from ci in db.tblCurrentIssues
                             where ci.CURENTISSUE_ARCHIVE_ID == current_Archive && ci.CURENTISSUE_ID==id
                             select new
                             {
                                 ci.CURENTISSUE_NAME,
                                 
                                  ci.CURENTISSUE_ABSTRACT,
                             }).SingleOrDefault();

           
            return Json(cur_issue, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Current_Issue()
        {
            var current_Archive = (db.tblArchives.OrderByDescending(x => x.ARCHIVE_YEAR).Take(1).Select(x=>x.ARCHIVE_DETAILS)).FirstOrDefault();
            ViewBag.CurentArchive = current_Archive;
            return View();
        }
    }
}
