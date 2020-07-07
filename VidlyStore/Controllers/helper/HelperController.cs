using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VidlyStore.Models;

namespace VidlyStore.Controllers.helper
{
    public class HelperController : Controller
    {private ApplicationDbContext _context;
        public HelperController()
        {
            _context = new ApplicationDbContext();
        }
        public void AddTask()
        {
            var TDate = System.Web.HttpContext.Current.Request.Form["TaskDate"];
            var Ttime = System.Web.HttpContext.Current.Request.Form["TaskTime"];
            var task = new task();
            task.describtion = System.Web.HttpContext.Current.Request.Form["describtion"];
            task.TaskDate = Convert.ToDateTime(TDate);
            task.TaskTime = TimeSpan.Parse(Ttime);

            task.ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            _context.task.Add(task);
            _context.SaveChanges();
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            
            if (files.Count != 0)
            {
           
                for (var i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    AddFile(file,task.Id);
                }
            }
        }

        // Get File From APi and Save it in database
        public void AddFile(HttpPostedFile file,int taskId)
        {

            var image = new Images();
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + extension;
            image.ImgPath = "~/Images/" + fileName;
            fileName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), fileName);
            file.SaveAs(fileName);
            image.taskId = taskId;
            _context.images.Add(image);
            _context.SaveChanges();
        }
    }
}