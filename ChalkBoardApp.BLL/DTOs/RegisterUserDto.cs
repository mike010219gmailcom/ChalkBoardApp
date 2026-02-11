using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkBoardApp.BLL.DTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
