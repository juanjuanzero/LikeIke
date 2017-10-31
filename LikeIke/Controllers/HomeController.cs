using LikeIke.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LikeIke.Controllers
{
    public class HomeController : Controller
    {
        //Seed data
        public static List<Task> TaskList = new List<Task>
        {
            new Task {TaskId=1, TaskName="First Task", DateDue="10-30-2017", Description="My second task", Duration=10.5 , Important=true},
            new Task {TaskId=2, TaskName="Second Task", DateDue="11-01-2017", Description="My third task", Duration=10.5,  Important=true },
            new Task {TaskId=3, TaskName="Third Task", DateDue="11-03-2017", Description="My fourth task", Duration=10.5,  Important=true },
            new Task {TaskId=4, TaskName="Fourth Task", DateDue="11-04-2017", Description="My fifth task", Duration=10.5 ,  Important=true},
            new Task {TaskId=5, TaskName="Fifth Task", DateDue="11-05-2017", Description="My  task", Duration=10.5, Important=true }
        };

        //STOCK LANGUAGE FROM MVC TEMPLATE IS BELOW
        public ActionResult Index()
        {
            //Go to the Home/Index folder and throw it into the view.
            //list all of the tasks from the seed data and push it to the view

            var _taskList = new TaskListViewModel
            {
                TaskList = TaskList.Select(p => new TaskViewModel
                {
                    TaskId = p.TaskId,
                    TaskName = p.TaskName,
                    Duration = p.Duration,
                    Description = p.Description,
                    DateDue = p.DateDue,
                    Important = p.Important
                }).ToList()
            };

            return View(_taskList);
        }

        //Reviewing the details of a task
        public ActionResult TaskDetail(int? id)
        {
            //search for a matching task from the TaskList list and store it in _task
            var _task = TaskList.SingleOrDefault(t => t.TaskId == id);
            //if there is a matching task then assign it to values to the viewModel to pass it to a view.
            if(_task != null)
            {
                //create a new variable that will be a new TaskViewModel and assign the corresponding properties.
                var _taskViewModel = new TaskViewModel
                {
                    TaskId = _task.TaskId,
                    TaskName = _task.TaskName,
                    Duration = _task.Duration,
                    Description = _task.Description,
                    DateDue = _task.DateDue,
                    Important = _task.Important

                };

                ViewBag.Title = "Review Task";

                return View(_taskViewModel);
            }

            return new HttpNotFoundResult();
        }


        //Open the AddEditTask cshtml task when this is called.
        public ActionResult AddEditTask()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}