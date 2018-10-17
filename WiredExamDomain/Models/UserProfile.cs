using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredExamDomain.Models
{
    public class UserProfile
    {
        [Key]
        public int userId { get; set; }
        [DisplayName("Kullanıcı adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string userName { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password)]
        public string password { get; set; }
    }
}
