using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DnDCharacterSheetTool.Classes.DataModel;
using DnDCharacterSheetTool.Classes.NewDataModel;
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
        public void TestModel()
        {
#pragma warning disable IDE0059 // Unnötige Zuweisung eines Werts.
            Model model = Model.GetInstance();
#pragma warning restore IDE0059 // Unnötige Zuweisung eines Werts.
        }

        [TestMethod]
        public void GenerateJSONSchema()
        {
            JSchemaGenerator schemaGenerator = new JSchemaGenerator();
            JSchema schema = schemaGenerator.Generate(typeof(List<Feat>));
            string help = schema.ToString();
            Trace.WriteLine(help);
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
                            if (Enum.TryParse(property.Value.ToString(), out DnDCharacterSheetTool.Classes.DataModel.SizeCategory category))
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
