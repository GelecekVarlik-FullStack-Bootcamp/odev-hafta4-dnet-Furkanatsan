using AutoMapper;
using IsYonetimPro.Data.Abstract;
using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Entities.Dtos;
using IsYonetimPro.Services.Abstract;
using IsYonetimPro.Shared.Utilities.Results.Abstract;
using IsYonetimPro.Shared.Utilities.Results.ComplexTypes;
using IsYonetimPro.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Services.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<EmployeeDto>> AddAsync(EmployeeAddDto employeeAddDto, int createdById)
        {
            var employee = _mapper.Map<Employee>(employeeAddDto);
            employee.CreatedById = createdById;//dto da almadığımız için burada ekledik.

            var addedEmployee= await _unitOfWork.Employee.AddAsync(employee);//veritabanına gönderdik.
            await _unitOfWork.SaveAsync();
            return new DataResult<EmployeeDto>(ResultStatus.Success, $"{employeeAddDto.EmployeeName} isimli çalışan sisteme kaydedildi.",new EmployeeDto { 
            ResultStatus=ResultStatus.Success,
            Employee=addedEmployee
            });
        }

        public async Task<IDataResult<EmployeeListDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employee.GetAllAsync(null/*, e => e.TaskEmployees, e => e.EmployeeDepartment*/);//includelar silinebilir
            if (employees!=null)
            {
                return new DataResult<EmployeeListDto>(ResultStatus.Success, new EmployeeListDto 
                {
                    Employees=employees,
                    ResultStatus=ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<EmployeeListDto>(ResultStatus.Error, "Bir hata oluştu.Çalışan listesi", null);
            }
        }

        public async Task<IDataResult<EmployeeListDto>> GetAllByDepartmentAsync(int departmentId)
        {
            var result = await _unitOfWork.Department.AnyAsync(d => d.DepartmentId == departmentId);
            if (result)
            {
                var employeeByDepartment = await _unitOfWork.Employee.GetAllAsync(e => e.EmployeeDepartmentId == departmentId/*, e => e.TaskEmployees, e => e.EmployeeDepartment*/);//includelar silinebilir.
                if (employeeByDepartment!=null)
                {
                    return new DataResult<EmployeeListDto>(ResultStatus.Success, new EmployeeListDto 
                    {
                    Employees=employeeByDepartment,
                    ResultStatus=ResultStatus.Success
                    });
                }
                else
                {
                    return new DataResult<EmployeeListDto>(ResultStatus.Error, "bir hata oluştu.Çalışan bulunamadı.", null);
                }
            }
            else
            {
                return new DataResult<EmployeeListDto>(ResultStatus.Error, "Bir hata oluştu.Departman bulunamadı.", null);
            }
            
        }

        public async Task<IDataResult<EmployeeDto>> GetAsync(int employeeId)
        {
            var employee = await _unitOfWork.Employee.GetAsync(e => e.EmployeeId == employeeId,e=>e.TaskEmployees,e=>e.EmployeeDepartment);//includelar silinebilir
            if (employee!=null)
            {
                return new DataResult<EmployeeDto>(ResultStatus.Success, new EmployeeDto
                {
                    Employee=employee,
                    ResultStatus=ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<EmployeeDto>(ResultStatus.Error, "bir hata oluştu.Çalışan bulunamadı", null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int employeeId)
        {
            var result = await _unitOfWork.Employee.AnyAsync(e => e.EmployeeId == employeeId);
            if (result)
            {
                var employee = await _unitOfWork.Employee.GetAsync(e => e.EmployeeId == employeeId);
                await _unitOfWork.Employee.DeleteAsync(employee);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{employee.EmployeeName} isimli çalışan silindi");
            }
            else
            {
                return new Result(ResultStatus.Error, "Bir hata oluştu.Silinemedi");
            }
        }
    }
}
