using ChalkBoardApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkBoardApp.BLL.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDto dto);
    }
}
