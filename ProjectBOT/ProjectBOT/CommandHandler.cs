using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;
using ProjectBOT.Common;

namespace ProjectBOT
{
    class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _cmds;

        public async Task InstallAsync(DiscordSocketClient c)
        {
            // Save an instance of the discord client.
            _client = c;
            // Create a new instance of the commandservice.
            _cmds = new CommandService();

            // Load all modules from the assembly.
            await _cmds.AddModulesAsync(Assembly.GetEntryAssembly());

            // Register the messagereceived event to handle commands.
            _client.MessageReceived += _HandleCommandsAsync;
        }

        private async Task _HandleCommandsAsync(SocketMessage s)
        {
            // Check if the received message is from an user.
            var msg = s as SocketUserMessage;
            if (msg == null)
                return;

            // Create a new command context.
            var context = new SocketCommandContext(_client, msg);

            User user = Globals.GetUser(context);
            // For Mantarias: Room to do some shady stuff here



            // For Mantarias: If you already did something above and don't want the bottom to get exected, you have to type in return;
            // Example: If User's ID is 2542375525, do not take any commands from him:
            // if (user.ID == 2542375525)
            // return;

            int argPos = 0;
            // Check if the message has either a string or mention prefix.
            if (msg.HasStringPrefix(Globals.Configuration.Prefix, ref argPos) ||
                msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                // Try and execute a command with the given context.
                var result = await _cmds.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    // If execution failed, reply with the error message.
                    Message message = new Message(result.ErrorReason);
                    await message.Send(context);
                }
            }
        }
    }
}