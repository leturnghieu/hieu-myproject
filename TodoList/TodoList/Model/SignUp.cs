using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Model
{
    public class SignUp
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Minimum eight characters, at least one uppercase letter,"
             + "one lowercase letter, one number and one special character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
