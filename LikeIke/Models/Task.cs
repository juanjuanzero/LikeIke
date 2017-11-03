using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeIke.Models
{
    public class Task
    {
        //properties for tasks yo!
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string DateDue { get; set; }
        public bool Important { get; set; }
        public bool Complete { get; set; }

    }
}