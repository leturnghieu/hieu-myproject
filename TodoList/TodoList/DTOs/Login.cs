using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs
{
    public class Login
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
