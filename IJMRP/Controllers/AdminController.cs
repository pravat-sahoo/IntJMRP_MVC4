using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IJMRP.Models;
using HtmlAgilityPack;
using IJMRP.ViewModel;
using System.IO;

namespace IJMRP.Controllers
{
    [Authorize]
    [ValidateInput(false)]

    public class AdminController : Controller
    {
        dbintjmrpEntities db = new dbintjmrpEntities();

        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult EditeHomePage()
        {

            var wt = db.tblWebtexts.Select(x=>x.WEB_ID).Distinct();
            List<SelectListItem> webid = new List<SelectListItem>();
            string defaultID = "ABOUT_US";
            foreach (var item in wt)
            {
                webid.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item,
                    Selected = (item == defaultID ? true : false)
                });
            }
           // var dropdown_roleVD = new SelectList(wt, "WEB_ID", "WEB_ID");
            ViewBag.WebtextId = webid;
            return View();

        }
        [HttpPost]
        public ActionResult EditeHomePage(tblWebtext ob_tblwebT)
        {
            try
            {
                var wt = db.tblWebtexts.Select(x => x.WEB_ID).Distinct();
                List<SelectListItem> webid = new List<SelectListItem>();
                string defaultID = "ABOUT_US";
                foreach (var item in wt)
                {
                    webid.Add(new SelectListItem()
                    {
                        Text = item,
                        Value = item,
                        Selected = (item == defaultID ? true : false)
                    });
                }
                // var dropdown_roleVD = new SelectList(wt, "WEB_ID", "WEB_ID");
                ViewBag.WebtextId = webid;

                tblWebtext obx = new tblWebtext();
                obx = db.tblWebtexts.Find(ob_tblwebT.WEB_ID);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(ob_tblwebT.WEB_DESC);

                foreach (var item in doc.DocumentNode.SelectNodes("//body"))// "//div" is a xpath which means select div nodes that are anywhere in the html
                {
                    obx.WEB_DESC = item.InnerHtml;//your div content
                }
                //= 
                obx.WEB_DATE = DateTime.Today.Date;
                if (ModelState.IsValid)
                {
                    db.SaveChanges();

                    ViewBag.SvaeSuccess = "Success";
                }
                //db.tblWebtexts.Add(obx);
            }
            catch(Exception ex)
            {
                ViewBag.EnterError = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public JsonResult Webtext(string id)
        {

            var tex=db.tblWebtexts.Where(x => x.WEB_ID == id).Select(x => x.WEB_DESC).FirstOrDefault();

            return Json(tex,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Upload_file()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload_file(int g)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Current_Issu_Del()
        {
            var current = db.tblCurrentIssues.OrderByDescending(x => x.CURENTISSUE_DATE).ToList();
            return View("Current_Issu_Del",current);
        }
        public ActionResult Current_Issu_Del2(int bid)
        {
            tblCurrentIssue ob = db.tblCurrentIssues.Find(bid);
            db.tblCurrentIssues.Remove(ob);
            db.SaveChanges();

            var current = db.tblCurrentIssues.OrderByDescending(x => x.CURENTISSUE_DATE).ToList();
            return View("Current_Issu_Del", current);
        }
        [HttpGet]
        public ActionResult Current_Issue()
        {
            var role_query = db.tblArchives.ToList();
            var dropdown_archiveVD = new SelectList(role_query, "ARCHIVE_DETAILS", "ARCHIVE_DETAILS");
            ViewBag.RoleVD = dropdown_archiveVD;

            var query = db.tblGroups.ToList();
            var dropdown = new SelectList(query, "GROUP_ID", "GROUP_ID");
            ViewBag.GroupVd = dropdown;
            return View();
        }
        [HttpPost]
        public ActionResult Current_Issue(tblCurrentIssue ob,HttpPostedFileBase file)
        {
            var query = db.tblGroups.ToList();
            var dropdown = new SelectList(query, "GROUP_ID", "GROUP_ID");
            ViewBag.GroupVd = dropdown;

            var role_query = db.tblArchives.ToList();
            var dropdown_archiveVD = new SelectList(role_query, "ARCHIVE_DETAILS", "ARCHIVE_DETAILS");
            ViewBag.RoleVD = dropdown_archiveVD;
            try
            {
                // tblArchive ob = new tblArchive();
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload_File"), guid + fileName);
                        file.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload_File/" + newpath;
                        ob.CURENTISSUE_FILEPATH = imagepath;
                    }
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(ob.CURENTISSUE_ABSTRACT);

                    foreach (var item in doc.DocumentNode.SelectNodes("//body"))// "//div" is a xpath which means select div nodes that are anywhere in the html
                    {
                        ob.CURENTISSUE_ABSTRACT = item.InnerHtml;//your div content
                    }
                    db.tblCurrentIssues.Add(ob);
                    db.SaveChanges();
                    ViewBag.sucess = "success";
                    ModelState.Clear();



                }
            }
            catch
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Archive()
        {
            ArchiveViewmodel ob_vtblarchive=new ArchiveViewmodel();
            ob_vtblarchive .ArchiveList= db.tblArchives.ToList();
            return View(ob_vtblarchive);
        }
        [HttpPost]
        public ActionResult Archive(ArchiveViewmodel ob_vtblarchive, HttpPostedFileBase file)
        {
            try
            {
                tblArchive ob = new tblArchive();
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {

                        var fileName = Path.GetFileName(file.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload_File"), guid + fileName);
                        file.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload_File/" + newpath;
                        ob.ARCHIVE_FILE = imagepath;
                    }
                    ob.ARCHIVE_DETAILS = ob_vtblarchive.singleArchive.ARCHIVE_DETAILS;

                    ob.ARCHIVE_YEAR = ob_vtblarchive.singleArchive.ARCHIVE_YEAR.Value.Date;
                    db.tblArchives.Add(ob);
                    ModelState.Clear();

                    db.SaveChanges();
                    ViewBag.SvaeSuccess = "success";
                }

            }
            catch
            {
                ViewBag.CreateEmpError = "error";
            }
            ob_vtblarchive.singleArchive = null;
            return View(ob_vtblarchive);
        }
        [HttpGet]
        public ActionResult ChangeValueArchive()
        {
            var role_query = db.tblArchives.ToList();
            var dropdown_archiveVD = new SelectList(role_query, "ARCHIVE_DETAILS", "ARCHIVE_DETAILS");
            ViewBag.archiveVD = dropdown_archiveVD;
            // Update model to your db  
            return View();
        } 
     
        
        [HttpPost]
        public ActionResult ChangeValueArchive(ArchiveViewmodel model, HttpPostedFileBase file)
        {
            var role_query = db.tblArchives.ToList();
            var dropdown_archiveVD = new SelectList(role_query, "ARCHIVE_DETAILS", "ARCHIVE_DETAILS");
            ViewBag.archiveVD = dropdown_archiveVD;
            // Update model to your db  
            tblArchive ob = new tblArchive();
            if (ModelState.IsValid)
            {
                ob = db.tblArchives.Find(model.singleArchive.ARCHIVE_DETAILS);
                if (file != null)
                {


                    var fileName = Path.GetFileName(file.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload_File"), guid + fileName);
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload_File/" + newpath;
                    ob.ARCHIVE_FILE = imagepath;
                }
               // ob = db.tblArchives.Find(model.singleArchive.ARCHIVE_DETAILS);
                //if (model.singleArchive.ARCHIVE_FILE!=null)
                //{
                //    ob.ARCHIVE_FILE = model.singleArchive.ARCHIVE_FILE;
  
                //}
                ob.ARCHIVE_YEAR = model.singleArchive.ARCHIVE_YEAR.Value.Date;
                //db.tblArchives.Add(ob);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        } 
         [HttpGet]
        public ActionResult Group()
        {
            //ArchiveViewmodel ob_vtblarchive=new ArchiveViewmodel();
            //ob_vtblarchive .ArchiveList= db.tblArchives.ToList();
            return View();
        }
         [HttpPost]
         public ActionResult Group(tblGroup ob)
         {
             if(ob.GROUP_ID!=null)
             {
                 db.tblGroups.Add(ob);
                 db.SaveChanges();
                 ViewBag.Suc = "success";
                 ModelState.Clear();
             }
             else
             {
                 ModelState.AddModelError(" ", "Enter value");
             }
             return View();
         }
        [HttpPost]
        public JsonResult changeArch(string id)
        {
            tblArchive model = new tblArchive();
            model = db.tblArchives.Find(id);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
//