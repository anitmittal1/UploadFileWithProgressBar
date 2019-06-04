using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class FileLoaderController : Controller
    {
        // GET: FileLoader
        public ActionResult Index(HttpContext context)
        {

            if(context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for(int i=0; i<files.Count; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    HttpPostedFile file = files[i];
                    string fileName = context.Server.MapPath("~/FileLoader/" + System.IO.Path.GetFileName(file.FileName));
                    file.SaveAs(fileName);
                }
            }

            return View();
        }
    }
}