using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUDwithADO.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name is requied")]
        [Display (Name ="User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is requied")]
        [Display(Name = "User Email")]
        [EmailAddress (ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Age is requied")]
        [Display(Name = "User Age")]
        [Range(18,60,ErrorMessage ="Age Must be in Between 18 to 60")]
        public int Age { get; set; }
    }
}