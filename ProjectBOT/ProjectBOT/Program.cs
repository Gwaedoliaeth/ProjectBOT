using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using ProjectBOT.Common;

namespace ProjectBOT
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _commands;

        public async Task StartAsync()
        {
            // Ensure the configuration file has been created.
            Configuration.EnsureExists();
            Globals.Configuration = Configuration.Load();

            // Create a new instance of DiscordSocketClient.
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                // Specify console verbose information level.
                LogLevel = LogSeverity.Verbose,
                // Tell discord.net how long to store messages (per channel).
                MessageCacheSize = 1000
            });

            // Register the console log event.
            _client.Log += (l)
                => Console.Out.WriteLineAsync(l.ToString());

            Globals.PrepareBot();

            await _client.LoginAsync(TokenType.Bot, Globals.Configuration.Token);
            await _client.StartAsync();

            // Initialize the command handler service
            _commands = new CommandHandler();
            await _commands.InstallAsync(_client);

            // Prevent the console window from closing.
            await Task.Delay(-1);
        }
    }
}
