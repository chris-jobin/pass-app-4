using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public partial class MessageComponent
    {
        public List<MessageModel> Messages { get; set; } = new();

        public async Task SetMessage(string text, int? duration, MessageType type, bool clear = true)
        {
            if (clear)
                Messages = new();
            var message = new MessageModel
            {
                Message = text,
                Duration = duration,
                Type = type
            };
            Messages.Add(message);
            StateHasChanged();
            if (duration != null)
            {
                await Task.Delay(duration.Value);
                Messages.Remove(message);
            }
            StateHasChanged();
        }
    }
}
