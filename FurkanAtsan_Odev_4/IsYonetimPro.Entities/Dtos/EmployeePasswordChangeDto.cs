using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Entities.Dtos
{
    public class EmployeePasswordChangeDto
    {
        [DisplayName("Şu Anki Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]//display name de dne yazıyorsa {0}buraya eklenicek.
        [MaxLength(6, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]//dinamik kullandık tehrar tekrar yazmamak için
        [MinLength(6, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DisplayName("Yeni Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]//display name de dne yazıyorsa {0}buraya eklenicek.
        [MaxLength(6, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]//dinamik kullandık tehrar tekrar yazmamak için
        [MinLength(6, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DisplayName("Tekrar Şifreniz")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]//display name de dne yazıyorsa {0}buraya eklenicek.
        [MaxLength(6, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]//dinamik kullandık tehrar tekrar yazmamak için
        [MinLength(6, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="şifreleriniz uyuşmalıdır.")]
        public string RepeatPassword { get; set; }
    }
}
