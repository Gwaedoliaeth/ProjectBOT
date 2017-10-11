using System;
using System.Text;
using System.Collections.Generic;
using Discord.Commands;
using System.Threading.Tasks;
using ProjectBOT.Common;
using System.Linq;

namespace ProjectBOT.Arena.Commands
{
    [Group("Race")]
    public class RaceModule : ModuleBase<SocketCommandContext>
    {
        [Command("List")]
        [Summary("Shows a full list of races.")]
        [Remarks("Race List")]
        public async Task RaceList()
        {
            Message message = new Message();
            message.Add($"Full list of races: ", string.Join(", ", Globals.Races.Select(x => x.Name).OrderBy(x => x)));
            await message.Send(Context);
        }
    }
}
