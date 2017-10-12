using System;
using System.Text;
using System.Collections.Generic;
using Discord.Commands;
using System.Threading.Tasks;
using ProjectBOT.Common;
using System.Linq;
using Discord;
using ProjectBOT.Common.Preconditions;

namespace ProjectBOT.Arena.Commands
{
    [Group("Admin")]
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("SaveData")]
        [Summary("Saves all the users data.")]
        [Remarks("Admin SaveData")]
        [MinPermissions(AccessLevel.ServerMod)]
        public async Task SaveData()
        {
            Message message = new Message("Saving data...");
            foreach (User user in Globals.Users)
            {
                IUser iUser = await Context.Channel.GetUserAsync(user.ID);
                message.Add(iUser.Username, "Data saved.");
                await user.SaveData();
            }
            await message.Send(Context);
        }

        [Command("ChangeEntriesPerPage")]
        [Summary("Sets a new value for entries per page.")]
        [Remarks("Admin EntriesPerPage 5")]
        [MinPermissions(AccessLevel.ServerMod)]
        public async Task EntriesPerPage([Summary("Number of new entries per page.")]int entries)
        {
            Message message = new Message($"Changed entries per page from {Configuration.EntriesPerPage} to {entries}");
            Configuration.EntriesPerPage = entries;
            await message.Send(Context);
        }
    }
}
