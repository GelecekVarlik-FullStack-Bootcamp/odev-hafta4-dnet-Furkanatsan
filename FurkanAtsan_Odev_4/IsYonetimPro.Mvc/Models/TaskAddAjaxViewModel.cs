using IsYonetimPro.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsYonetimPro.Mvc.Models
{
    public class TaskAddAjaxViewModel
    {
        public TaskAddDto TaskAddDto { get; set; }
        public string TaskAddPartial { get; set; }

        public TaskDto TaskDto { get; set; }
    }
}
