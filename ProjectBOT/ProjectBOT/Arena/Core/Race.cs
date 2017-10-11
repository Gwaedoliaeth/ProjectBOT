using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;

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
}
