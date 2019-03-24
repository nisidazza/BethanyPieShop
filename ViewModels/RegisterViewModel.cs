using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")] //the display attribute will override that in the UI, user name without a space will be shown, this value instead will be shown
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

