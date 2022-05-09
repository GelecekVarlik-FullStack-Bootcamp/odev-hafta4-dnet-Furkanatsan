using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class Task:EntityBase,IEntity
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public int? CreatedBy { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int TaskDepartmentId { get; set; }
        public int TaskImportanceId { get; set; }
        public int TaskStatusId { get; set; }
        public int? TaskMessageId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual Department TaskDepartment { get; set; }
        public virtual TaskImportance TaskImportance { get; set; }
        public virtual TaskMessage TaskMessage { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
    }
}
