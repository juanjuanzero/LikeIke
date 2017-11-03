using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeIke.Models
{
    public class TaskViewModel
    {
        ////properties for tasks yo. the view model will be passed into the the AddEditTask View under the Home folder. the TaskId is declared nullable with the "?" since there is an instance where we might not get a TaskId.
             
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string DateDue { get; set; }
        public bool Important { get; set; }
        public bool Complete { get; set; }
    }
}