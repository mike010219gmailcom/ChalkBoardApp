using ChalkBoardApp.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace ChalkBoardApp.BLL.Interfaces
{
    public interface IMessageService
    {
        Task CreateMessageAsync(string messageText, string username);
        Task<List<MessageDto>> GetAllMessagesAsync(string currentUsername);
        Task UpdateUsernameOnMessagesAsync(string oldUsername, string newUsername);
        Task MarkUserAsDeletedAsync(string username);
    }
}
