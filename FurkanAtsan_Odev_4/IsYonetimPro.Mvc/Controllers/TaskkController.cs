using IsYonetimPro.Entities.Dtos;
using IsYonetimPro.Mvc.Extensions;
using IsYonetimPro.Mvc.Models;
using IsYonetimPro.Services.Abstract;
using IsYonetimPro.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IsYonetimPro.Mvc.Controllers
{
    [Authorize]
    public class TaskkController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskkController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _taskService.GetAllAsync();//dataResult döner
            if (result.ResultStatus==ResultStatus.Success)//Dönen DataResult içindeki resultStatus Success ise datayı view a göndeririz. 
            {
                return View(result.Data);
            }
            return View();
        }

        //Add
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_TaskAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskAddDto taskAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _taskService.AddAsync(taskAddDto,1);//1=createdbyId
                if (result.ResultStatus==ResultStatus.Success)//result başarılı ise kullanıcıya model nöneriz
                {
                    var taskAddAjaxModel = JsonSerializer.Serialize(new TaskAddAjaxViewModel
                    {
                        TaskDto=result.Data,
                        TaskAddPartial=await this.RenderViewToStringAsync("_TaskAddPartial",taskAddDto)//stringe cevirim gönderdik
                    });
                    return Json(taskAddAjaxModel);

                }

            }
                var taskAddAjaxError = JsonSerializer.Serialize(new TaskAddAjaxViewModel
                {
                    TaskAddPartial = await this.RenderViewToStringAsync("_TaskAddPartial", taskAddDto)//stringe cevirim gönderdik
                });
                return Json(taskAddAjaxError);
            
        }

        //Delete
        [HttpDelete]
        public async Task<JsonResult> Delete(int taskId)
        {
            var result = await _taskService.HardDeleteAsync(taskId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);


        }
    }
}
