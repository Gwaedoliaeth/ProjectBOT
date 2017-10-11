using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBOT.Arena.Base.Enums
{
    public enum AttributeType
    {
        Strength = 0,
        Dexterity = 1,
        Constitution = 2,
        Intelligence = 3,
        Wisdom = 4,
        Charisma = 5
    }

    public class Globals
    {
        /// <summary>
        /// Get string value of the enum
        /// </summary>
        /// <param name="type">Enum type</param>
        /// <returns></returns>
        public static string GetName(Enum type)
            => Enum.GetName(type.GetType(), type);
    }
}
