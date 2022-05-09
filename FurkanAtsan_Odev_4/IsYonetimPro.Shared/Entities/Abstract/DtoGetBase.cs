using IsYonetimPro.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        //override edilebilir olması için abstract olarak verdik.
        public virtual ResultStatus? ResultStatus { get; set; }//dönüş tipine göre farklı viewlar gösterebiliriz.

    }
}
