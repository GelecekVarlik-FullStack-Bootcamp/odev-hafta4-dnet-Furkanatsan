using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IsYonetimPro.Data.Abstract
{
    public interface ITaskRepository:IEntityRepository<Task>
    {
    }
}
