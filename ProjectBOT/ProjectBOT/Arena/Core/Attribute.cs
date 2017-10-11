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

            // If race isn't specified, just roll 4 times and substract lowest
            if (race == null)
            {
                List<int> rolls = new List<int>();
                for (int i = 1; i <= 4; i++)
                    rolls.Add(Globals.Random.Next(1, 7));
                attribute.Base = (rolls.Sum() - rolls.OrderBy(x => x).FirstOrDefault());
            }
            // If race is specified, use specific rolls for each attribute
            else
            {
                RaceAttribute ra = race.Attributes.Where(x => x.Type == type).FirstOrDefault();
                List<int> rolls = new List<int>();
                for (int i = 1; i <= ra.Rolls; i++)
                    rolls.Add(Globals.Random.Next(1, 7));
                attribute.Base = ra.Base + rolls.Sum();
            }

            return attribute;
        }
    }
}
