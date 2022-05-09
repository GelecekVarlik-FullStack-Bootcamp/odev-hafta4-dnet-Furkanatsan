using IsYonetimPro.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsYonetimPro.Mvc.Models
{
    public class EmployeeAddAjaxViewModel
    {
        public EmployeeAddDto EmployeeAddDto { get; set; }
        public string EmployeeAddPartial { get; set; }
        public EmployeeDto EmployeeDto { get; set; }
    }
}
