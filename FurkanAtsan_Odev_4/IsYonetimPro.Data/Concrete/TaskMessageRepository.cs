﻿using IsYonetimPro.Data.Abstract;
using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Data.Concrete
{
    public class TaskMessageRepository : EfEntityRepositoryBase<TaskMessage>, ITaskMessageRepository
    {
        public TaskMessageRepository(DbContext context) : base(context)
        {
        }
    }
}
