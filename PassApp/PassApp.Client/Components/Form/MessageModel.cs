using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public class MessageModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public MessageType Type { get; set; }
        public int? Duration { get; set; }
        public string MessageClass => Type switch
        {
            MessageType.Success => "alert alert-success border border-success",
            MessageType.Error => "alert alert-danger border border-danger",
            MessageType.Warning => "alert alert-warning border border-warning",
            _ => ""
        };
    }

    public enum MessageType
    {
        Success,
        Error,
        Warning
    }
}
