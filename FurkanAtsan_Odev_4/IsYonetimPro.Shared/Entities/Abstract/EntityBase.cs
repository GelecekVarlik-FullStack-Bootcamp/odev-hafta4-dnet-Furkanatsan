using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public virtual int?  CreatedById { get; set; }

    }
}
