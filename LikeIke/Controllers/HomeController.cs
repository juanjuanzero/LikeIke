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
        //public static List<Task> TaskList = new List<Task>
        //{
        //    //new Task {TaskId=1, TaskName="First Task", DateDue="10/30/2017", Description="My first task", Duration=10.5 , Important=true, Complete=false},
        //    //new Task {TaskId=2, TaskName="Second Task", DateDue="11/01/2017", Description="My second task", Duration=10.5,  Important=true, Complete=false },
        //    //new Task {TaskId=3, TaskName="Third Task", DateDue="11/03/2017", Description="My third task", Duration=10.5,  Important=true, Complete=true },
        //    //new Task {TaskId=4, TaskName="Fourth Task", DateDue="11/04/2017", Description="My fourt task", Duration=10.5 ,  Important=true, Complete=false },
        //    //new Task {TaskId=5, TaskName="Fifth Task", DateDue="11/05/2017", Description="My fifth task", Duration=10.5, Important=true, Complete=false }
        //};


        public ActionResult Index()
        {
            //Go to the Home/Index folder and throw it into the view.
            //list all of the tasks from the seed data and push it to the view

            using(var taskContext = new LikeIkeContext())
            {
                var _taskList = new TaskListViewModel
                {
                    TaskList = taskContext.Task.Select(p => new TaskViewModel
                    {
                        TaskId = p.TaskId,
                        TaskName = p.TaskName,
                        Duration = p.Duration,
                        Description = p.Description,
                        DateDue = p.DateDue,
                        Important = p.Important,
                        Complete = p.Complete,
                        Urgent = p.Urgent
                    }).ToList()
                };

                return View(_taskList);
            }

            
        }

        //Reviewing the details of a task
        public ActionResult TaskDetail(int? id)
        {
            using(var taskContext = new LikeIkeContext())
            {
                //search for a matching task from the TaskList list and store it in _task
                var _task = taskContext.Task.SingleOrDefault(t => t.TaskId == id);
                //if there is a matching task then assign it to values to the viewModel to pass it to a view.
                if (_task != null)
                {
                    //create a new variable that will be a new TaskViewModel and assign the corresponding properties.
                    var _taskViewModel = new TaskViewModel
                    {
                        TaskId = _task.TaskId,
                        TaskName = _task.TaskName,
                        Duration = _task.Duration,
                        Description = _task.Description,
                        DateDue = _task.DateDue,
                        Important = _task.Important,
                        Complete = _task.Complete,
                        Urgent = _task.Urgent

                    };

                    ViewBag.Title = "Review a Task";

                    return View(_taskViewModel);
                }
            }
            

            return new HttpNotFoundResult();
        }


        /// When this method is called from the Index view of Home by hitting the "Edit" button it will create an empty ViewModel and push it to the  AddEditTask view.

        public ActionResult AddTask()
        {
            var _addTaskViewModel = new TaskViewModel() { DateDue = DateTime.Now };


            ViewBag.Mode = "Add";

            return View("AddEditTask",_addTaskViewModel);
            

        }

        //when this method is called from the AddEditTask view by clicking the "add" button. it will take the elements from the view, create a new obj of type Task and add it to the list called TaskList. Also increment the id by 1
        [HttpPost]
        public ActionResult TaskAdd(TaskViewModel _taskAddViewModel)
        {
            using(var taskContext = new LikeIkeContext())
            {
                //var nextId = TaskList.Count()+1; you cant just count the number of elements because Task id is assigned from the highest number
                //var nextId = taskContext.Task.Max(t => t.TaskId) + 1;
                var _taskAdd = new Task
                {
                    //TaskId = nextId,
                    TaskName = _taskAddViewModel.TaskName,
                    DateDue = _taskAddViewModel.DateDue,
                    Description = _taskAddViewModel.Description,
                    Duration = _taskAddViewModel.Duration,
                    Important = _taskAddViewModel.Important,
                    Complete = _taskAddViewModel.Complete,
                    Urgent = _taskAddViewModel.Urgent
                };

                taskContext.Task.Add(_taskAdd);
                taskContext.SaveChanges();                
            }

            return RedirectToAction("Index");
        }

        //CRUD Operation: EDIT/UPDATE. When clicking on the "edit" button from the index view are going to find a matching id from the list of tasks, check if it is null, then set the matching tasks to a viewmodel then pass the obj to the AddEditTask viewmodel

        public ActionResult EditTask(int id)
        {
            using(var taskContext = new LikeIkeContext())
            {
                var _task = taskContext.Task.SingleOrDefault(t => t.TaskId == id);

                if (_task != null)
                {
                    var _editTaskViewModel = new TaskViewModel
                    {
                        TaskId = _task.TaskId,
                        TaskName = _task.TaskName,
                        DateDue = _task.DateDue,
                        Description = _task.Description,
                        Duration = _task.Duration,
                        Important = _task.Important,
                        Complete = _task.Complete,
                        Urgent = _task.Urgent
                    };

                    return View("AddEditTask", _editTaskViewModel);
                }
            }
            

            return new HttpNotFoundResult();
        }

        //This method takes in submissions from the form in the AddEditTask view and UPDATES the records in the list with the matching id that the viewmodel has.

        [HttpPost]
        public ActionResult TaskEdit(TaskViewModel _taskEditViewModel)
        {
            using(var taskContext = new LikeIkeContext())
            {
                var _task = taskContext.Task.SingleOrDefault(t => t.TaskId == _taskEditViewModel.TaskId);

                if (_task != null)
                {
                    //if there is a match set the values equal to the edit fields in the view model.
                    _task.TaskName = _taskEditViewModel.TaskName;
                    _task.DateDue = _taskEditViewModel.DateDue;
                    _task.Description = _taskEditViewModel.Description;
                    _task.Duration = _taskEditViewModel.Duration;
                    _task.Important = _taskEditViewModel.Important;
                    _task.Complete = _taskEditViewModel.Complete;
                    _task.Urgent = _taskEditViewModel.Urgent;

                    taskContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            

            return new HttpNotFoundResult();
        }

        //CRUD Operation DELETING FILES: This would be a deletion by clicking the delete button from the Task Manager (Index) page. When the delete button is clicked a modal pops up to get a TaskViewModel object with a matching id. Then when you click this method is called and takes in the TaskViewModel object. It would take in a TaskViewModel obj from a matching item in the TaskList and then once it is found it is deleted from the list. We will be passing in a an input with a name of TaskId and that should match the viewModel's parameter
        
        [HttpPost]
        public ActionResult DeleteTask(TaskViewModel _taskViewModel)
        {
            using(var taskContext = new LikeIkeContext())
            {
                var _task = taskContext.Task.SingleOrDefault(t => t.TaskId == _taskViewModel.TaskId);

                if (_task != null)
                {
                    taskContext.Task.Remove(_task);
                    taskContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult CompleteTask(TaskViewModel _taskViewModel)
        {
            using(var taskContext = new LikeIkeContext())
            {
                var _task = taskContext.Task.SingleOrDefault(t => t.TaskId == _taskViewModel.TaskId);

                if (_task != null)
                {
                    if(_task.Complete == false)
                    {
                        _task.Complete = true;
                        taskContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _task.Complete = false;
                        taskContext.SaveChanges();

                        return EditTask(_task.TaskId);
                    }
                    
                    
                }
            }
            

            return new HttpNotFoundResult();
        }
        
        
        //CRUD OPERATION: saving the progress means that we are going to delete the tasks that have a check mark on them. Take the TaskList, check if the complete value is =true. If it is true then remove the task from the TaskList list.
        [HttpPost]
        public ActionResult SaveByDelete()
        {
            //from the modal update the parameters of each task. to complete if their corresponding checkbox is checked.
            //from the modal the tasklist is passed into this action          
            using(var taskContext = new LikeIkeContext())
            {
                //Calling the Where query on the TaskContext Task and looking for a function that returns a bool.
                var tasksToRemove = taskContext.Task.Where(t => t.Complete).ToList();

                for (var i = 0; i < tasksToRemove.Count() ; i++)
                {
                    taskContext.Task.Remove(tasksToRemove[i]);
                    taskContext.SaveChanges();
                }
                
                //for (var i = 0; i < taskContext.Task.Count(); i++)
                //{
                //    if (taskContext.Task.ElementAt(i).Complete == true)
                //    {
                //        taskContext.Task.Remove(taskContext.Task.ElementAt(i));
                //        taskContext.SaveChanges();
                //    }
                //}

                return RedirectToAction("Index");
            }
            
        }

        //STOCK LANGUAGE FROM MVC TEMPLATE IS BELOW
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