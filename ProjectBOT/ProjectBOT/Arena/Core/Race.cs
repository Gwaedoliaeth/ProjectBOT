using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;

namespace ProjectBOT.Arena.Core
{
    public class Race
    {
        /// <summary>
        /// Race name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// List containing attributes and their bonuses.
        /// Example of stored item in a list: AttributeType.Strength, 1
        /// </summary>
        public List<RaceAttribute> Attributes { get; set; } = new List<RaceAttribute>();

        
        public Race() { }
    }

    public class RaceAttribute
    {
        public AttributeType Type { get; set; }
        public int Base { get; set; }
        public int Rolls { get; set; }

        public RaceAttribute() { }

        public RaceAttribute(AttributeType type, int baseValue, int rolls)
        {
            this.Type = type;
            this.Base = baseValue;
            this.Rolls = rolls;
        }
    }
}
