using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeIke.Models
{
    public class TaskListViewModel
    {
        //created a list called TaskList. This list of TasksViewModels will be a list of taks that we can use for unit testing prior to linking with a database.
        public List<TaskViewModel> TaskList { get; set; }
    }
}