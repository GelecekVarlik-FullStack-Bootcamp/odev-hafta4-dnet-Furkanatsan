using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
