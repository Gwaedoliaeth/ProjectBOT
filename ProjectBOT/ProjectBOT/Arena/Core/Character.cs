using Newtonsoft.Json;
using ProjectBOT.Arena.Base;
using ProjectBOT.Arena.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBOT.Arena.Core
{
    public class Character
    {
        public string Name { get; set; }
        public string RaceName { get; set; }
        public string ClassName { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();
        public CurrentMaximum HitPoints { get; set; } = new CurrentMaximum();
        public CurrentMaximum ManaPoints { get; set; } = new CurrentMaximum();

        [JsonIgnore]
        public Race Race { get { return Globals.Races.Where(x => x.Name == this.RaceName).FirstOrDefault(); } }
        [JsonIgnore]
        public Class Class { get { return Globals.Classes.Where(x => x.Name == this.ClassName).FirstOrDefault(); } }

        // Gear
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();


        public Character() { }

        public static Character Create(Race race, string name)
        {
            Character result = new Character();

            result.Name = name;

            result.Attributes = new List<Attribute>();
            result.Attributes.Add(Attribute.Create(race, AttributeType.Strength));
            result.Attributes.Add(Attribute.Create(race, AttributeType.Dexterity));
            result.Attributes.Add(Attribute.Create(race, AttributeType.Constitution));
            result.Attributes.Add(Attribute.Create(race, AttributeType.Intelligence));
            result.Attributes.Add(Attribute.Create(race, AttributeType.Wisdom));
            result.Attributes.Add(Attribute.Create(race, AttributeType.Charisma));

            return result;
        }
    }
}
