using IsYonetimPro.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Entities.Dtos
{
    public class EmployeeAddDto
    {
        [DisplayName("isim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string EmployeeName { get; set; }
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string EmployeeSurname { get; set; }
        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]//display name de dne yazıyorsa {0}buraya eklenicek.
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]//dinamik kullandık tekrar tekrar yazmamak için
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string EmployeeEmail { get; set; }
        [DisplayName("Telefon Numarası")]
        //[MaxLength(12, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]//dinamik kullandık tehrar tekrar yazmamak için
        //[MinLength(11, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]//5515515151
        public decimal? EmployeePhone { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
        [DisplayName("Departman")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [Range(1, 5, ErrorMessage = "ID 1'den küçük 5'ten büyük olamaz.")]
        public int EmployeeDepartmentId { get; set; }
        //public Department? Department { get; set; }//Navigation prop
        [DisplayName("Çalışan Niteliği")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [Range(1, 3, ErrorMessage = "ID 1'den küçük 3'ten büyük olamaz.")]
        public int EmployeeRoleId { get; set; }
        //public Role? Role { get; set; }//Navigation prop
    }
}
