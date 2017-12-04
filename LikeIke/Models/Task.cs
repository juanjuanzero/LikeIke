using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LikeIke.Models
{
    public class Task
    {
        //properties for tasks yo!
        public int TaskId { get; set; }
        //[Required]
        [Display(Name ="Task Name")]
        [StringLength(80,ErrorMessage ="The name of the Task cannot be longer than 80 characters")]
        public string TaskName { get; set; }
        public string Description { get; set; }

        //[Range(0,40,ErrorMessage ="The length of time to do this cannot not be longer than 40 hrs.")]
        public double Duration { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Due Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =  true)]
        public DateTime DateDue { get; set; }

        public bool Important { get; set; }
        public bool Complete { get; set; }
        public bool Urgent { get; set; }

    }
}