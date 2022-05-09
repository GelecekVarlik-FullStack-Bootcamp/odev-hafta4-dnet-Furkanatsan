using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Entities.Dtos
{
    public class TaskListDto:DtoGetBase
    {
        public IList<IsYonetimPro.Entities.Concrete.Task> Task { get; set; }
    }
}
