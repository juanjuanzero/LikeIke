using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LikeIke.Models
{
    public class TaskViewModel
    {
        ////properties for tasks yo. the view model will be passed into the the AddEditTask View under the Home folder. the TaskId is declared nullable with the "?" since there is an instance where we might not get a TaskId.
        //[Required]
        [Display(Name = "Task Name")]
        //[StringLength(80, ErrorMessage = "The name of the Task cannot be longer than 80 characters")]
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }

        //[Range(0, 40, ErrorMessage = "The length of time to do this cannot not be longer than 40 hrs.")]
        public double Duration { get; set; }

        [Display(Name = "Due Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime DateDue { get; set; }
        public bool Important { get; set; }
        public bool Complete { get; set; }
        public bool Urgent { get; set; }
    }
}