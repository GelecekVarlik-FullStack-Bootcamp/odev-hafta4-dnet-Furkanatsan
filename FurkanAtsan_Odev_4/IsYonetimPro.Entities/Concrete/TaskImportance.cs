using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class TaskImportance
    {
        public TaskImportance()
        {
            Tasks = new HashSet<Task>();
        }

        public int ImportanceId { get; set; }
        public string ImportanceStatus { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
