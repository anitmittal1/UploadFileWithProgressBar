using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View("Upload");
        }

        public JsonResult Upload()//ImageUpload model)
        {
            var file = Request.Files[0];// model.ImageFile;

            if (file != null)
            {
                System.Threading.Thread.Sleep(1000);
                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                string pathFolder = Server.MapPath("~/ImageUpload/");
                string path = Server.MapPath("~/ImageUpload/" + file.FileName);
                if (!Directory.Exists(pathFolder))
                    Directory.CreateDirectory(pathFolder);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                file.SaveAs(Server.MapPath("~/ImageUpload/" + file.FileName));
                System.Threading.Thread.Sleep(1000);

            }

            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }
    }
}