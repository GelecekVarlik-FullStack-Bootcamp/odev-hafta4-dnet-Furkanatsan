using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class Department : IEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Tasks = new HashSet<Task>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
