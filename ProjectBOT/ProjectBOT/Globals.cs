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

        public static List<User> Users = new List<User>();


        public static Races Races { get; set; } = new Races();
        public static List<Class> Classes { get; set; } = new List<Class>();

        internal static void PrepareBot()
        {
            Random = new Random();
            PrepareRaces();
            PrepareClassses();
        }

        private static void LoadSavedData()
        {
            Users = new List<User>();
            string directory = Path.Combine(AppContext.BaseDirectory, "SavedData");
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    Users.Add(JsonConvert.DeserializeObject<User>(File.ReadAllText(file)));
                }
            }
        }

        private static void PrepareClassses()
        {
            string file = Path.Combine(AppContext.BaseDirectory, Class.FileName);
            if (File.Exists(file))
            {
                // Get classes from json file
                Classes = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText(file));
                Console.WriteLine($"Classes loaded: {Classes.Count}");
            }
            else
            {
                // Create classes and save to json
                Class fighter = new Class();
                fighter.Name = "Fighter";
                fighter.HitDiceType = 10;
                fighter.SavingThrowsAttributes.Add(AttributeType.Strength);
                fighter.SavingThrowsAttributes.Add(AttributeType.Constitution);

                Class barbarian = new Class();
                barbarian.Name = "Barbarian";
                barbarian.HitDiceType = 12;
                barbarian.SavingThrowsAttributes.Add(AttributeType.Strength);
                barbarian.SavingThrowsAttributes.Add(AttributeType.Constitution);
                

                Classes.Add(fighter);
                Classes.Add(barbarian);

                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                File.WriteAllText(file, JsonConvert.SerializeObject(Classes));
            }
        }

        private static void PrepareRaces()
        {
            string file = Path.Combine(AppContext.BaseDirectory, Race.FileName);
            if (File.Exists(file))
            {
                // Get races from json file
                Races = JsonConvert.DeserializeObject<Races>(File.ReadAllText(file));
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
                Races.Add(halforc);
                Races.Add(halfling);
                Races.Add(human);
                Races.Add(thiefling);

                string path = Path.GetDirectoryName(file);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                File.WriteAllText(file, JsonConvert.SerializeObject(Races));
            }
        }
    }
}
