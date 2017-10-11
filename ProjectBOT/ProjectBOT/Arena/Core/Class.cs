using System;
using System.Collections.Generic;
using System.Text;
using ProjectBOT.Arena.Base.Enums;

namespace ProjectBOT.Arena.Core
{
    public class Class
    {
        public static string FileName { get { return "core/classes.json"; } }

        public string Name { get; set; }
        public int HitDiceType { get; set; }
        public int ManaDiceType { get; set; }
        public List<AttributeType> SavingThrowsAttributes { get; set; } = new List<AttributeType>();
        public AttributeType? SpellcastingAttribute { get; set; }

        public Class() { }
    }
}
