using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VidlyStore.Models;
using VidlyStore.Models.viewModels;

namespace VidlyStore.Controllers
{
    [Authorize]
    public class TodoListController : Controller
    {
        private ApplicationDbContext _context;

        public  TodoListController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: TodoList
        public ActionResult Index()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            
            var allTasks = new List<TaskViewModel>();
            var today = DateTime.Today;
            var tasks = _context.task.Where(t => DbFunctions.TruncateTime(t.TaskDate) == today && 
                                                 t.ApplicationUserId == userId).OrderBy(t =>t.TaskTime).ToList();
            if (tasks.Count !=0)
            {
                
                foreach (var task in tasks)
                {
                    var taskViewModel = new TaskViewModel();
                    taskViewModel = addImaages(task);
                    allTasks.Add(taskViewModel);
                }
            }

            return View(allTasks);
        }

        // GET: TodoList/Details/5
        public ActionResult Detail(int id)
        {
            var task = _context.task.SingleOrDefault(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            else
            {
                var taskViewModel = new TaskViewModel();
                taskViewModel = addImaages(task);
                return View(taskViewModel);
            }
           
        }

        // GET: TodoList/Create
        public ActionResult New()
        {
            return View();
        }


        public ActionResult allTasks(FormCollection collection)
        {
           
           
                return View();
            
        }

        public ActionResult TasksList()
        {
            return View();
        }
     
        

        public TaskViewModel addImaages(task task)
        {
            var taskViewModel = new TaskViewModel();
            taskViewModel.task = task;
            var images = _context.images.Where(i => i.taskId == task.Id).ToList();
            if (images.Count != 0)
            {
                foreach (var image in images)
                {
                    if (taskViewModel.images == null)
                    {
                        //It's null - create it
                        taskViewModel.images = new List<Images>();
                    }
                    taskViewModel.images.Add(image);
                }
            }

            return taskViewModel;
        }

        // generate Json object for Calender
        public JsonResult GetCalender()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var events = _context.task.Where(t => t.ApplicationUserId == userId).ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


    }
}
