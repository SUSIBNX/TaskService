using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ParentTask { get; set; }
        public string Task { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> PriorityEnd { get; set; }
    }
}
