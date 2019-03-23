using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")] //the display attribute will override that in the UI, user name without a space will be shown, this value instead will be shown
        public string LoginUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}
