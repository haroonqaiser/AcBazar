using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcBazar.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/content/images/proImages/"), fileName);
                file.SaveAs(path);
                result.Data = new { Sucess = true, ImageURL = string.Format("/content/images/proImages/{0}", fileName)};

                //var newImage = new Image() {Name = fileName};
                //if (ImageService.Instance.SaveNewImage(newImage))
                //{
                //    result.data = new { Sucess = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{
                //    result.date = new { Sucess = false, Message = new HttpStatusCodeResult(500) };
                //}
            }
            catch (Exception ex)
            {
                result.Data = new { Sucess = false, Message = ex.Message};
            }
            return result;
        }
    }
}