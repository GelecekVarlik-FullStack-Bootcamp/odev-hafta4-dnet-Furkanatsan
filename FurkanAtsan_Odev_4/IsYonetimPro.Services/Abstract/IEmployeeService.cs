using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Entities.Dtos;
using IsYonetimPro.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Services.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<EmployeeDto>> GetAsync(int employeeId);
        Task<IDataResult<EmployeeListDto>> GetAllAsync();
        Task<IDataResult<EmployeeListDto>> GetAllByDepartmentAsync(int departmentId);//departmana göre çalışanları getir.
        Task<IDataResult<EmployeeDto>> AddAsync(EmployeeAddDto employeeAddDto, int createdById);//veri eklediğimizde  geriye employeeDto dönmüş olacagız.bu sayede eklediğimiz verinin son hali elimizde olucak ve bunuda tablomuza ve toastera eklemek için kullanacagız.
        Task<IResult> HardDeleteAsync(int employeeId);//gerçekten siler.
    }
}
