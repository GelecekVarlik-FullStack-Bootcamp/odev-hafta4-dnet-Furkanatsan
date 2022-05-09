using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class TaskMessage:EntityBase,IEntity
    {
        public TaskMessage()
        {
            Employees = new HashSet<Employee>();
            Tasks = new HashSet<Task>();
        }

        public int MessageId { get; set; }
        public string MessageDescription { get; set; }
        public DateTime MessgeDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
