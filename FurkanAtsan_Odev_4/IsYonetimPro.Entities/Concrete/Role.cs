using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace IsYonetimPro.Entities.Concrete
{
    public partial class Role:IEntity
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
