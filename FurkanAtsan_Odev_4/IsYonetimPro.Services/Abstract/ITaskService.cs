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
    public interface ITaskService
    {
        Task<IDataResult<TaskDto>> GetAsync(int taskId);
        Task<IDataResult<TaskListDto>> GetAllAsync();
        Task<IDataResult<TaskDto>> AddAsync(TaskAddDto taskAddDto,int createdById);//veri eklediğimizde  geriye taskDto dönmüş olacagız.bu sayede eklediğimiz verinin son hali elimizde olucak ve bunuda tablomuza eklemek için kullanacagız.
        Task<IResult> DeleteAsync(int taskId);//isDeleted i true yapar
        Task<IResult> HardDeleteAsync(int taskId);//gerçekten siler.
    }
}
