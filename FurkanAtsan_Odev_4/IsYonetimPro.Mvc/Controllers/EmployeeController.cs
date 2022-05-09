using IsYonetimPro.Entities.Concrete;
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
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            
        }
        
        
        public async Task<IActionResult> Index()
        {
            var result = await _employeeService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)//Dönen DataResult içindeki resultStatus Success ise datayı view a göndeririz. 
            {
                return View(result.Data);
            }
            return View();
        }
        //Add
        
        
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_EmployeeAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto employeeAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.AddAsync(employeeAddDto,1);//1=createdbyId
                if (result.ResultStatus == ResultStatus.Success)//result başarılı ise kullanıcıya model nöneriz
                {
                    var employeeAddAjaxModel = JsonSerializer.Serialize(new EmployeeAddAjaxViewModel
                    {
                        EmployeeDto = result.Data,
                        EmployeeAddPartial = await this.RenderViewToStringAsync("_EmployeeAddPartial", employeeAddDto)//stringe cevirip gönderdik
                    });
                    return Json(employeeAddAjaxModel);

                }

            }
            var employeeAddAjaxError = JsonSerializer.Serialize(new EmployeeAddAjaxViewModel
            {
                EmployeeAddPartial = await this.RenderViewToStringAsync("_EmployeeAddPartial", employeeAddDto)//stringe cevirim gönderdik
            });
            return Json(employeeAddAjaxError);

            
        }
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }
    }
}
