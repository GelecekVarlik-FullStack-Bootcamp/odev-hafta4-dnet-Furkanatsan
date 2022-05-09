using IsYonetimPro.Data.Abstract;
using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IsYonetimPro.Data.Concrete
{
    public class TaskRepository : EfEntityRepositoryBase<Task>, ITaskRepository
    {
        //tüm ortak methodlar EfEntityRepositoryBase de
        public TaskRepository(DbContext context) : base(context)
        {
        }
    }
}
