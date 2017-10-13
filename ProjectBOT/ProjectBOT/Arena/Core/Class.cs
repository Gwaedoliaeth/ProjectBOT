using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;
using System.Linq;
using ProjectBOT.Arena.Base.Interface;
using ProjectBOT.Arena.Base;

namespace ProjectBOT.Arena.Core
{
    public class Class : IEntry
    {

        public static string FileName { get { return "core/classes.json"; } }

        public string Name { get; set; }
        public int HitDiceType { get; set; }
        public int ManaDiceType { get; set; }
        public List<AttributeType> SavingThrowsAttributes { get; set; } = new List<AttributeType>();
        public AttributeType? SpellcastingAttribute { get; set; }

        public Class() { }

        public class Classes : ProjectBotList<Class>
        {

        }
    }
}
