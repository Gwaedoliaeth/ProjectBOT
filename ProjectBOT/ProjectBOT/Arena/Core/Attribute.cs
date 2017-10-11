using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;
using System.Linq;

namespace ProjectBOT.Arena.Core
{
    public class Attribute
    {
        /// <summary>
        /// Gets a list of all attributes in correct order.
        /// </summary>
        public static List<AttributeType> AttributeTypes
        {
            get
            {
                List<AttributeType> list = new List<AttributeType>();
                list.Add(AttributeType.Strength);
                list.Add(AttributeType.Dexterity);
                list.Add(AttributeType.Constitution);
                list.Add(AttributeType.Intelligence);
                list.Add(AttributeType.Wisdom);
                list.Add(AttributeType.Charisma);
                return list;
            }
        }

        public AttributeType Type { get; set; }
        public int Base { get; set; }

        [JsonIgnore]
        public string Name { get { return ProjectBOT.Arena.Base.Enums.Globals.GetName(Type); } }
        [JsonIgnore]
        public int Modifier { get { return (int)(this.Base / 2) - 5; } }

        public Attribute() { }

        /// <summary>
        /// Creates a string in the pattern Base/+-Modifier
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"{this.Base.ToString()}/{(this.Modifier >= 0 ? "+" : "")}{this.Modifier.ToString()}";

        /// <summary>
        /// Creates a string in the pattern AttributeTypeName: Base/+-Modifier
        /// </summary>
        /// <returns></returns>
        public string ToStringWithName()
            => $"{this.Name}: {this.Base.ToString()}/{(this.Modifier >= 0 ? "+" : "")}{this.Modifier.ToString()}";


        public static Attribute Create(Race race, AttributeType type)
        {
            Attribute attribute = new Attribute();
            attribute.Type = type;

            // 4d6 substract lowest
            List<int> rolls = new List<int>();
            for (int i = 1; i <= 4; i++)
                rolls.Add(Globals.Random.Next(1, 7));
            attribute.Base = (rolls.Sum() - rolls.OrderBy(x => x).FirstOrDefault());


            // If race is specified, use specific modifier for attribute
            if (race != null && race.AttributeModifiers.ContainsKey(type))
            {
                attribute.Base += race.AttributeModifiers[type];
            }

            return attribute;
        }
    }
}
