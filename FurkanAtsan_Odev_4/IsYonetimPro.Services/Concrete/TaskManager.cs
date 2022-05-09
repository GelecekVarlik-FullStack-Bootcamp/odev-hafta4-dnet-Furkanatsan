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
using Task = IsYonetimPro.Entities.Concrete.Task;

namespace IsYonetimPro.Services.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
       
        
        public async Task<IDataResult<TaskDto>> AddAsync(TaskAddDto taskAddDto, int createdById)
        {
            var taskk = _mapper.Map<IsYonetimPro.Entities.Concrete.Task>(taskAddDto);
            taskk.CreatedById = createdById;
            taskk.CreatedBy = createdById;
            taskk.CreatedDate = DateTime.Now;
            var addedTask= await _unitOfWork.Task.AddAsync(taskk);
            await _unitOfWork.SaveAsync();
            return new DataResult<TaskDto>(ResultStatus.Success, $"{taskAddDto.TaskTitle} adlı iş eklenmiştir.",new TaskDto {
            Taskk=addedTask,
            ResultStatus=ResultStatus.Success
            });//eklenen işi ekranda göstermek için taskDto döndük.
        }

        public async Task<IResult> DeleteAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<TaskListDto>> GetAllAsync()
        {
            var taskks = await _unitOfWork.Task.GetAllAsync();
            if (taskks!=null)
            {
                return new DataResult<TaskListDto>(ResultStatus.Success, new TaskListDto 
                {
                    Task=taskks,
                    ResultStatus=ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<TaskListDto>(ResultStatus.Error,"bir hata oluştu.",null);
            }
        }


        public async Task<IDataResult<TaskDto>> GetAsync(int taskId)
        {
           var taskk= await _unitOfWork.Task.GetAsync(t => t.TaskId == taskId);
            if (taskk!=null)
            {
                return new DataResult<TaskDto>(ResultStatus.Success,new TaskDto 
                {
                    Taskk=taskk,
                    ResultStatus=ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<TaskDto>(ResultStatus.Error, "Böyle bir iş bulunamadı.",null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int taskId)
        {
            var taskk = await _unitOfWork.Task.GetAsync(t => t.TaskId == taskId);
            if (taskk!=null)
            {
                await _unitOfWork.Task.DeleteAsync(taskk);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{taskk.TaskTitle} Başlıklı iş silinmiştir.");
            }
            else
            {
                return new Result(ResultStatus.Error, " B");
            }
        }
    }
}
