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
        int stage = 0;
        int chosen;
        string chosenClass = "";
        string chosenName = "";
        string discordUser = "";
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

            Message messages = new Message();


            
            if (msg.ToString() == "!create character"&& stage == 0)
            {
                stage = 1;
                messages.Add($"Type in the name of the race or number next to it ", string.Join(", ", Globals.Races.ToDisplayList()));
                await messages.Send(context);
                discordUser = user.ToString();
                return;
            }
            if (stage == 1 && user.ToString() == discordUser)
            {
                switch (msg.ToString())
                {
                    case "8":
                    case "tiefling":

                        chosen = 8;
                        messages.Add("You have chosen:", "Tiefling");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "7":
                    case "human":

                        chosen = 7;
                        messages.Add("You have chosen:", "human");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "6":
                    case "halfling":

                        chosen = 6;
                        messages.Add("You have chosen:", "halfling");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "5":
                    case "half-orc":

                        chosen = 5;
                        messages.Add("You have chosen:", "half-orc");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "4":
                    case "gnome":

                        chosen = 4;
                        messages.Add("You have chosen:", "gnome");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "3":
                    case "elf":

                        chosen = 3;
                        messages.Add("You have chosen:", "elf");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "2":
                    case "dwarf":

                        chosen = 2;
                        messages.Add("You have chosen:", "dwarf");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    case "1":
                    case "dragonborn":

                        chosen = 1;
                        messages.Add("You have chosen:", "dragonborn");
                        messages.Add("Choose a class", string.Join("Choose a class", string.Join(", ", Globals.Classes.ToDisplayList())));
                        await messages.Send(context);

                        stage = 2;
                        break;
                    default:
                        messages.Add(msg.ToString(), "is not a valid choice");
                        await messages.Send(context);
                        break;
                }
                return;

            }
            if (stage == 2)
            {
                switch (msg.ToString())
                {
                    case "1":
                    case "fighter":
                        chosenClass = "Fighter";
                        messages.Add("You have chosen:", chosenClass);
                        messages.Add("Chose a name", "for you character");
                        await messages.Send(context);

                        stage = 3;
                        break;
                    case "2":
                    case "barbarian":

                        chosenClass = "Barbarian";
                        messages.Add("You have chosen:", chosenClass);
                        messages.Add("Chose a name", "for you character");
                        await messages.Send(context);

                        stage = 3;
                        break;
                    default:
                        messages.Add(msg.ToString(), "is not a valid choice");
                        await messages.Send(context);
                        break;
                }
                return;
            }
            if (stage == 3 && user.ToString() == discordUser)
            {
                chosenName = msg.ToString();
                messages.Add("Character created with name: ", chosenName);
                messages.Add("Race:", "placeholder");
                messages.Add("Class:", chosenClass);
                await messages.Send(context);
                stage = 0;
                Arena.Core.Character.Create(Globals.Races[chosen],chosenName);
                return; 
                    
            }





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