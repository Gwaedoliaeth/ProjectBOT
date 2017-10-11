using System;
using System.Collections.Generic;
using ProjectBOT.Common;
using ProjectBOT.Test;
using ProjectBOT.Arena.Core;
using ProjectBOT.Arena.Base.Enums;
using Newtonsoft.Json;
using System.IO;

namespace ProjectBOT
{
    public class Globals
    {
        /// <summary>
        /// Configuration data for the BOT.
        /// </summary>
        public static Configuration Configuration;

        public static Random Random;

        public static List<Race> Races { get; set; } = new List<Race>();

        internal static void PrepareBot()
        {
            Random = new Random();
            PrepareRaces();

        }

        private static void PrepareRaces()
        {
            string file = Path.Combine(AppContext.BaseDirectory, Race.FileName);
            if (File.Exists(file))
            {
                // Get races from json file
                Races = JsonConvert.DeserializeObject<List<Race>>(File.ReadAllText(file));
                Console.WriteLine($"Races loaded: {Races.Count}");
            }
            else
            {
                // Create races and save to json
                Race human = new Race();
                human.Name = "Human";
                foreach (AttributeType type in ProjectBOT.Arena.Core.Attribute.AttributeTypes)
                    human.AttributeModifiers.Add(type, 1);

                Race elf = new Race();
                elf.Name = "Elf";
                elf.AttributeModifiers.Add(AttributeType.Dexterity, 2);

                Race dragonborn = new Race();
                dragonborn.Name = "Dragonborn";
                dragonborn.AttributeModifiers.Add(AttributeType.Strength, 2);
                dragonborn.AttributeModifiers.Add(AttributeType.Charisma, 1);

                Race dwarf = new Race();
                dwarf.Name = "Dwarf";
                dwarf.AttributeModifiers.Add(AttributeType.Constitution, 2);

                Race gnome = new Race();
                gnome.Name = "Gnome";
                gnome.AttributeModifiers.Add(AttributeType.Intelligence, 2);

                //Race halfelf = new Race();
                //halfelf.Name = "Half-Elf";
                //halfelf.AttributeModifiers.Add(AttributeType.Charisma, 4);

                Race halforc = new Race();
                halforc.Name = "Half-Orc";
                halforc.AttributeModifiers.Add(AttributeType.Strength, 2);
                halforc.AttributeModifiers.Add(AttributeType.Constitution, 1);

                Race halfling = new Race();
                halfling.Name = "Halfling";
                halfling.AttributeModifiers.Add(AttributeType.Dexterity, 2);

                Race thiefling = new Race();
                thiefling.Name = "Thiefling";
                thiefling.AttributeModifiers.Add(AttributeType.Intelligence, 1);
                thiefling.AttributeModifiers.Add(AttributeType.Charisma, 2);



                Races.Add(dragonborn);
                Races.Add(dwarf);
                Races.Add(elf);
                Races.Add(gnome);
                //Races.Add(halfelf);
                Races.Add(halforc);
                Races.Add(halfling);
                Races.Add(human);
                Races.Add(thiefling);


                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string racesJson = JsonConvert.SerializeObject(Races);

                File.WriteAllText(file, racesJson);
            }
        }
    }
}
