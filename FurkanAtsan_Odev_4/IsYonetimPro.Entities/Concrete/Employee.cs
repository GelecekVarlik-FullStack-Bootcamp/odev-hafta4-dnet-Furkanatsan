using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class Employee : EntityBase, IEntity
    {
        public Employee()
        {
            TaskCreatedByNavigations = new HashSet<Task>();
            TaskEmployees = new HashSet<Task>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public decimal? EmployeePhone { get; set; }
        public string EmployeePassword { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeRoleId { get; set; }
        public int? EmployeeMessageId { get; set; }
        

        public virtual Department EmployeeDepartment { get; set; }
        public virtual TaskMessage EmployeeMessage { get; set; }
        public virtual Role EmployeeRole { get; set; }
        public virtual ICollection<Task> TaskCreatedByNavigations { get; set; }
        public virtual ICollection<Task> TaskEmployees { get; set; }
    }
}
