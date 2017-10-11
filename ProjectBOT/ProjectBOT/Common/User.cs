using Newtonsoft.Json;
using ProjectBOT.Arena.Core;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjectBOT.Common
{
    public class User
    {
        /// <summary>
        /// ID taken from the User.ID
        /// </summary>
        public ulong ID { get; set; }
        /// <summary>
        /// String used for mentioning an user.
        /// </summary>
        public string Mention { get; set; }
        /// <summary>
        /// Currently used character.
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// File name for the current User.
        /// </summary>
        [JsonIgnore]
        public string FileName { get { return $"saves/{this.ID}.json"; } }

        public User() { }

        public User(ulong id, string mention)
        {
            this.ID = id;
            this.Mention = mention;
        }

        /// <summary>
        /// Saves Data for the current User
        /// </summary>
        /// <returns></returns>
        public async Task SaveData()
        {
            string file = Path.Combine(AppContext.BaseDirectory, this.FileName);
            if (!File.Exists(file))
            {
                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            using (StreamWriter writer = File.CreateText(file))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }
    }
}
