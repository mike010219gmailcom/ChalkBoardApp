using ChalkBoardApp.BLL.DTOs;
using ChalkBoardApp.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkBoardApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task RegisterUserAsync(RegisterUserDto dto)
        {
            // 1. Grundläggande validering
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password is required");

            // 2. Password + Confirm Password
            if (dto.Password != dto.ConfirmPassword)
                throw new ArgumentException("Passwords do not match");

            // 3. Skapa användaren
            var user = new IdentityUser
            {
                UserName = dto.Username
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(e => e.Description));

                throw new ArgumentException(errors);
            }
        }
    }
}
