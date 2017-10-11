using System;
using System.Text;
using System.Collections.Generic;
using Discord.Commands;
using System.Threading.Tasks;
using ProjectBOT.Common;
using System.Linq;

namespace ProjectBOT.Arena.Commands
{
    [Name("Help")]
    public class CoreModule : ModuleBase<SocketCommandContext>
    {
        private CommandService _service;

        // Create a constructor for the commandservice dependency
        public CoreModule(CommandService service)
        {
            _service = service;
        }

        [Command("Help")]
        [Summary("Shows a list of commands.")]
        public async Task HelpAsync()
        {
            Message message = new Message("These are the commands you can use");

            foreach (var module in _service.Modules)
            {
                string description = string.Empty;
                foreach (var cmd in module.Commands)
                {
                    var result = await cmd.CheckPreconditionsAsync(Context);
                    if (result.IsSuccess)
                        description += $"{Globals.Configuration.Prefix}{cmd.Aliases.First()} {string.Join(", ", cmd.Parameters.Select(p => p.Name))}{Environment.NewLine}";
                }

                if (!string.IsNullOrEmpty(description))
                    message.Add(module.Name, description);
            }

            await message.Send(Context);
        }

        [Command("Help")]
        [Summary("Shows a detailed info about a command.")]
        [Remarks("Help Help")]
        public async Task HelpAsync([Summary("Command.")][Remainder]string command)
        {
            var result = _service.Search(Context, command);

            if (!result.IsSuccess)
                throw new Exception($"Couldn't find a command like **{command}**");

            Message message = new Message($"Here are some commands like **{command}**");

            foreach (var match in result.Commands)
            {
                var cmd = match.Command;

                message.Add(string.Join(", ", cmd.Aliases),
                    $"Summary: {cmd.Summary}{Environment.NewLine}" +
                    $"Parameters: {string.Join(", ", cmd.Parameters.Select(p => p.Name))}{Environment.NewLine}" +
                    $"Example: {Globals.Configuration.Prefix}{cmd.Remarks}"
                );
            }

            await message.Send(Context);
        }
    }
}
