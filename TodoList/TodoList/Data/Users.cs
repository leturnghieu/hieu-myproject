using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Data
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
