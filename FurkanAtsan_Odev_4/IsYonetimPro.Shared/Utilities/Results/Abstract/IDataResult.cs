using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get; }//ister bir task isterse bir taskList atabiliriz."out" sayesende tek prop içinde liste veya entity taşıyabiliyoruz.Frklı proplar yapmamıza gerek kalmıyor. //new DataResult<Task>(ResultStatus.Success,Task); 
                                    //new DataResult<IList<Task>>(ResultStatus.Success,TaskList); 

    }
}
