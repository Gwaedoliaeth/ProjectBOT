using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace ProjectBOT.Common
{
    public class Message : EmbedBuilder
    {
        public Message()
        {
            this.Color = new Color(114, 137, 218);
        }

        public Message(string description)
        {
            this.Color = new Color(114, 137, 218);
            this.Description = description;
        }

        public void Add(string name, string text)
            => this.AddField(x => { x.Name = name; x.Value = text; x.IsInline = false; });

        public Embed Create()
            => this.Build();

        public async Task Send(SocketCommandContext context)
            => await context.Channel.SendMessageAsync("", false, this.Create());
    }
}
