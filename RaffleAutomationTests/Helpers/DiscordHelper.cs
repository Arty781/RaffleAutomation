using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public partial class DiscordHelper
    {
        public static async Task Announce() // 1
        {
            DiscordSocketClient _client = new DiscordSocketClient(); // 2
            ulong id = 907902939849437238; // 3
            var chnl = _client.GetChannel(id) as IMessageChannel; // 4
            await chnl.SendMessageAsync("Announcement!"); // 5

        }
    }
}
