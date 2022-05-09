using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
