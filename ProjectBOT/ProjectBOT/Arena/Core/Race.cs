using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;
using System.Linq;

namespace ProjectBOT.Arena.Core
{
    public class Race
    {
        public static string FileName { get { return "core/races.json"; } }

        /// <summary>
        /// Race name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Dictionary of attribute modifiers.
        /// </summary>
        public Dictionary<AttributeType, int> AttributeModifiers { get; set; } = new Dictionary<AttributeType, int>();

        
        public Race() { }
    }


    public class Races : List<Race>
    {
        public Races() { }

        public string ToDisplayList(int page = 1)
        {
            StringBuilder sb = new StringBuilder();
            int index = page == 1 ? 0 : (page - 1) * Common.Configuration.EntriesPerPage;
            List<Race> races = this.Skip(index).Take(Common.Configuration.EntriesPerPage).ToList();
            for (int i = 0; i < races.Count; i++)
                sb.AppendLine($"{index + i + 1}  {races[i].Name}");

            return sb.ToString();
        }
    }
}
