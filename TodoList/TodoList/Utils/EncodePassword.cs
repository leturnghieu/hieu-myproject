using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Utils
{
    public static class EncodePassword
    {
        public static string key = "letrunghieuabcd@@123";
        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += key;
            var PasswordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(PasswordBytes);
        }
    }
}
