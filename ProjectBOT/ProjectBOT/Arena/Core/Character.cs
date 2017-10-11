using ProjectBOT.Arena.Base.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBOT.Arena.Core
{
    public class Character
    {
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; } = new List<Attribute>();


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
