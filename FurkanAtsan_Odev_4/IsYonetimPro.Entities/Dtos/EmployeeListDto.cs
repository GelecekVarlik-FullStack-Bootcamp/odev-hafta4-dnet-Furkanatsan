using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Shared.Entities.Abstract;
using IsYonetimPro.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Entities.Dtos
{
    public class EmployeeListDto:DtoGetBase
    {
        public IList<Employee> Employees { get; set; }
    }
}
