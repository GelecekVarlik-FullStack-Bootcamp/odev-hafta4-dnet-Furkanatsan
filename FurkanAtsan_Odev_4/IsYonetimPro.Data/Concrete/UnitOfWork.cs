using IsYonetimPro.Data.Abstract;
using IsYonetimPro.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IsYonetimSistemiDBContext _context;
        private TaskRepository _taskRepository;//return ederken newleyeceğimiz için readonly olmaz
        private EmployeeRepository _employeeRepository;
        private RoleRepository _roleRepository;
        private TaskMessageRepository _taskMessageRepository;
        private DepartmentRepository _departmentRepository;
        public UnitOfWork(IsYonetimSistemiDBContext context)
        {
            _context = context;
        }
        //(??) operatörü sayesinde değişken değeri null ise alternatif değer döndürebiliriz.
        public ITaskRepository Task => _taskRepository ?? new TaskRepository(_context);//lamdba exp ile  gönderiyoruz.(??)_taskRepo null ise newleyip gönderiyoruz.

        public IEmployeeRepository Employee => _employeeRepository ?? new EmployeeRepository(_context);

        public IRoleRepository Role => _roleRepository ?? new RoleRepository(_context);

        public ITaskMessageRepository TaskMessage => _taskMessageRepository ?? new TaskMessageRepository(_context);

        public IDepartmentRepository Department => _departmentRepository ?? new DepartmentRepository(_context);
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
