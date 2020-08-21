using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DnD_3._5_Character_Sheet_Tool.Classes.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace FunctionTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void LoadAndSaveSpells()
        {
            List<Race> spells = DataLoader.Load<Race>("Races.json");
            DataLoader.Save<Race>(spells, "Races.json");
        }

        [TestMethod]
        public void ReWrite()
        {
            string help = "";
            for (int i = 0; i < 6; i++)
            {
                help += $"{i} - {(Attributes)i}\n";
            }
        }

        [TestMethod]
        public void ReadFileNames()
        {
            string path = "D:\\Dateien\\Fesdtplarre Flo\\Rollenspiel\\# D&D\\Wizards of the Coast\\Englisch";
            var help = Directory.GetFiles(path);
            List<string> strings = new List<string>();
            List<SourceBook> sourceBooks = new List<SourceBook>();
            foreach (string item in help)
            {
                string temp = item.Remove(item.Length - 4, 4).Remove(0, path.Length + 1);
                
                List<string> a = temp.Split(' ').ToList();
                SourceBook sb = new SourceBook();
                sb.Category = a.FirstOrDefault() == "DARK" ? a[0] + " " + a[1] : a[0];
                if(a.FirstOrDefault() == "DARK") 
                { 
                    a.RemoveAt(0); 
                    a.RemoveAt(0); 
                } 
                else 
                    a.RemoveAt(0);

                sb.Edition = a.FirstOrDefault();
                a.RemoveAt(0);
                temp = String.Join(" ", a);

                List<string> x = temp.Split('-').ToList();
                x.RemoveAt(0);
                temp = String.Join("", x).Trim("(°)".ToCharArray()).Trim();
                sb.Name = temp;
                strings.Add(temp);
                sourceBooks.Add(sb);
            }
            DataLoader.Save<SourceBook>(sourceBooks.OrderBy(x => x.Edition).ThenBy(X => X.Name).ToList(), "SourceBooks.json");
            string output = String.Join(",\n", strings.OrderBy(x => x).Distinct());
        }

        [TestMethod]
        public void GenerateJSONSchema()
        {
            JSchemaGenerator schemaGenerator = new JSchemaGenerator();
            JSchema schema = schemaGenerator.Generate(typeof(List<Race>));
            string help = schema.ToString();
        }

        [TestMethod]
        public void ReWriteRaceTemp()
        {
            var help = DataLoader.Load<object>("RaceTEMP.json");
            List<Race> races = new List<Race>();
            List<PropertyInfo> properties = typeof(Race).GetProperties().ToList();

            foreach (JObject tempRace in help)
            {
                Race race = new Race()
                {
                    Type = CreatureType.Humanoid
                };
                foreach (JProperty property in tempRace.Properties())
                {
                    switch (property.Name)
                    {
                        case "Name":
                            race.Name = property.Value.ToString();
                            break;
                        case "BasedOn":
                            race.SubraceOf = property.Value.ToString();
                            break;
                        case "Subtype":
                            List<CreatureSubTypes> subTypes = new List<CreatureSubTypes>();
                            List<string> typesToConvert = (property.Value as JArray).ToObject<List<string>>();
                            typesToConvert.ForEach(x =>
                            {
                                if(x.ToLower() != "humanoid")
                                {
                                    if(Enum.TryParse(x, out CreatureSubTypes creatureSubTypes))
                                    {
                                        subTypes.Add(creatureSubTypes);
                                    }
                                    else
                                    {
                                        System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                                    }
                                }
                            });
                            race.SubTypes = subTypes;
                            break;
                        case "HD":
                            if (int.TryParse(property.Value.ToString(), out int i))
                                race.CountHitDice = i;
                            else
                                System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                        case "LA":
                            if (int.TryParse(property.Value.ToString(), out int j))
                                race.LevelAdjustment = j;
                            else
                                System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                        case "FavouredClass":
                            if (property.Value.ToString().ToLower() != "any")
                                race.FavoredClass = property.Value.ToString();
                            else
                                race.FavoredClass = null;
                            break;
                        case "Size":
                            if (Enum.TryParse(property.Value.ToString(), out SizeCategory category))
                                race.SizeCategory = category;
                            else
                                System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                        case "Movement":
                            if (int.TryParse(property.Value.ToString(), out int k))
                                race.Movement = new Dictionary<MovementMode, int>() { { MovementMode.Ground, k } };
                            else
                                System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                        case "Vision":
                            string vision = property.Value.ToString().ToLower();
                            int trimIndex;
                            if (vision == "low-light")
                                race.Senses = new Dictionary<Sense, int?>() { { Sense.Low_Light, null } };
                            else if(vision.StartsWith("darkvision"))
                            {
                                trimIndex = vision.IndexOf(" ") + 1;
                                int? range = int.TryParse(vision.Substring(trimIndex), out int m) ? (int?)m : null;
                                race.Senses = new Dictionary<Sense, int?>() { { Sense.Darkvision, range } };
                            }
                            else
                                System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                        case "StatChanges":
                            race.StatChanges = (property.Value as JArray).ToObject<List<StatChange>>();
                            break;
                        case "RaceFeatures":
                            race.RaceFeatures = (property.Value as JArray).ToObject<List<object>>();
                            break;
                        default:
                            System.Diagnostics.Trace.WriteLine($"- Skipped {property.Name} '{property.Value}' of object {race.Name}, index {races.Count()}");
                            break;
                    }
                }
                races.Add(race);
            }

            DataLoader.Save<Race>(races, "Races.json");
        }
    }
}
