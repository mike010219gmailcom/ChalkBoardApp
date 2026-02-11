using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkBoardApp.BLL.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public string Username { get; set; }
        public bool IsOwnMessage { get; set; }

    }
}
