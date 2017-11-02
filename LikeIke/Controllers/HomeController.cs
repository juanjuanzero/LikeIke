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
            new Task {TaskId=1, TaskName="First Task", DateDue="10/30/2017", Description="My first task", Duration=10.5 , Important=true},
            new Task {TaskId=2, TaskName="Second Task", DateDue="11/01/2017", Description="My second task", Duration=10.5,  Important=true },
            new Task {TaskId=3, TaskName="Third Task", DateDue="11/03/2017", Description="My third task", Duration=10.5,  Important=true },
            new Task {TaskId=4, TaskName="Fourth Task", DateDue="11/04/2017", Description="My fourt task", Duration=10.5 ,  Important=true},
            new Task {TaskId=5, TaskName="Fifth Task", DateDue="11/05/2017", Description="My fifth task", Duration=10.5, Important=true }
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

                ViewBag.Title = "Review a Task";

                return View(_taskViewModel);
            }

            return new HttpNotFoundResult();
        }


        /// When this method is called from the Index view of Home by hitting the "Edit" button it will create an empty ViewModel and push it to the  AddEditTask view.

        public ActionResult AddTask()
        {
            var _addTaskViewModel = new TaskViewModel();
            //{
            //    _addTaskViewModel.DateDue = DateTime.Today.ToShortDateString();
            //};

            ViewBag.Mode = "Add";

            return View("AddEditTask",_addTaskViewModel);
            

        }

        //when this method is called from the AddEditTask view by clicking the "add" button. it will take the elements from the view, create a new obj of type Task and add it to the list called TaskList. Also increment the id by 1
        [HttpPost]
        public ActionResult TaskAdd(TaskViewModel _taskAddViewModel)
        {
            var nextId = TaskList.Count()+1;

            var _taskAdd = new Task
            {
                TaskId = nextId,
                TaskName = _taskAddViewModel.TaskName,
                DateDue = _taskAddViewModel.DateDue,
                Description = _taskAddViewModel.Description,
                Duration = _taskAddViewModel.Duration,
                Important = _taskAddViewModel.Important
            };

            TaskList.Add(_taskAdd);


            return RedirectToAction("Index");
        }

        //CRUD Operation: EDIT/UPDATE. When clicking on the "edit" button from the index view are going to find a matching id from the list of tasks, check if it is null, then set the matching tasks to a viewmodel then pass the obj to the AddEditTask viewmodel

        public ActionResult EditTask(int id)
        {
            var _task = TaskList.SingleOrDefault(t => t.TaskId == id);

            if(_task != null)
            {
                var _editTaskViewModel = new TaskViewModel
                {
                    TaskId = _task.TaskId,
                    TaskName = _task.TaskName,
                    DateDue = _task.DateDue,
                    Description = _task.Description,
                    Duration = _task.Duration,
                    Important = _task.Important
                };

                return View("AddEditTask", _editTaskViewModel);
            }

            return new HttpNotFoundResult();
        }

        //This method takes in submissions from the form in the AddEditTask view and UPDATES the records in the list with the matching id that the viewmodel has.

        [HttpPost]
        public ActionResult TaskEdit(TaskViewModel _taskEditViewModel)
        {
            var _task = TaskList.SingleOrDefault(t => t.TaskId == _taskEditViewModel.TaskId);

            if(_task != null)
            {
                //if there is a match set the values equal to the edit fields in the view model.
                _task.TaskName = _taskEditViewModel.TaskName;
                _task.DateDue = _taskEditViewModel.DateDue;
                _task.Description = _taskEditViewModel.Description;
                _task.Duration = _taskEditViewModel.Duration;
                _task.Important = _taskEditViewModel.Important;

                return RedirectToAction("Index");
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