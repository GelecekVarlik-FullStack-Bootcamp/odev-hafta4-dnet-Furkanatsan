using AutoMapper;
using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Services.AutoMapper.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeAddDto, Employee>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now)).ReverseMap();//içindeki bir prop için bir işlem yapmak istiyorum. dest ile hengi prop üzerinde işlem yapmak istediğimizi belirtiyoruz ve opt.MapFrom ile de değerini veriyoruz.EmployeeAddDto içinde createdDate alanımız yoktu bu yaptığımız işlem sayesende mapper içerisinde createdDate=DateTime.now yapabildik.
            CreateMap<Employee, EmployeeDto>().ReverseMap();

        }
    }
}
