using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;
using System.Linq;
using ProjectBOT.Arena.Base.Interface;
using ProjectBOT.Arena.Base;

namespace ProjectBOT.Arena.Core
{
    public class Race : IEntry
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


    public class Races : ProjectBotList<Race>
    {
        
    }
}
