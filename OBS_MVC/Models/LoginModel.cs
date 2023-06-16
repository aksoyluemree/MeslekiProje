namespace OBS_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class LoginModel
    {
        [Required(ErrorMessage = "Tc kimlik no girin")]
        [Display(Name = "Tc Kimlik No")]
        public string TcNo { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}