using ChalkBoardApp.BLL.DTOs;
using ChalkBoardApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkBoardApp.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        // Create a new message
        public async Task CreateMessageAsync(string messageText, string username)
        {
            if (string.IsNullOrWhiteSpace(messageText))
                throw new ArgumentException("Message cannot be empty");

            var message = new MessageModel
            {
                Message = messageText,
                Username = username,
                Date = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
        // Hämta alla meddelanden (nyast först)
        public async Task<List<MessageDto>> GetAllMessagesAsync(string currentUsername)
        {
            return await _context.Messages
                .OrderByDescending(m => m.Date)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Date = m.Date,
                    Message = m.Message,
                    Username = m.Username,
                    IsOwnMessage = m.Username == currentUsername
                })
                .ToListAsync();
        }
        // Om användare byter namn
        public async Task UpdateUsernameOnMessagesAsync(string oldUsername, string newUsername)
        {
            var messages = await _context.Messages
                .Where(m => m.Username == oldUsername)
                .ToListAsync();

            foreach (var message in messages)
            {
                message.Username = newUsername;
            }

            await _context.SaveChangesAsync();
        }
        // Om användare tar bort sitt konto
        public async Task MarkUserAsDeletedAsync(string username)
        {
            var messages = await _context.Messages
                .Where(m => m.Username == username)
                .ToListAsync();

            foreach (var message in messages)
            {
                message.Username = $"{username} (deleted user)";
            }

            await _context.SaveChangesAsync();
        }

    }
}
