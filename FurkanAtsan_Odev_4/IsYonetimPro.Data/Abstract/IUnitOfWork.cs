using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ITaskRepository Task { get; } //unitofwork.task
        IEmployeeRepository Employee { get; }//unitofwork.employee.AddAsync();
        IRoleRepository Role { get; }
        ITaskMessageRepository TaskMessage { get; }
        IDepartmentRepository Department { get; }

        Task<int> SaveAsync();//etkilenen kayıt sayısını almak için  int verdik.

    }
}
