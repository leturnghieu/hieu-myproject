using TodoList.DTOs;
using TodoList.Models;
using TodoList.Utils;

namespace TodoList.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateUser(this Users users, Register register)
        {
            users.UserName = register.UserName;
            users.Password = EncodePassword.ConvertToEncrypt(register.Password);
        }
    }
}
