using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DnDCharacterSheetTool.Classes.DataModel;
using DnDCharacterSheetTool.Classes.EFModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestModel()
        {
            using (var entities = new CharacterCreator.DataModel.Entities())
            {
                Trace.WriteLine(entities.Spells.First().Name);
            }
        }

        [TestMethod]
        public void ImportJSONToDB()
        {
            using (var entities = new CharacterCreator.DataModel.Entities())
            {
                List<CharacterCreator.DataModel.CreatureType> editions = DataLoader.Load<CharacterCreator.DataModel.CreatureType>("CreatureTypes.json").OrderBy(x => x.ID).ToList();
                entities.CreatureTypes.AddRange(editions);
                entities.SaveChanges();
            }
        }

        [TestMethod]
        public void GenerateJSONSchema()
        {
            JSchemaGenerator schemaGenerator = new JSchemaGenerator();
            JSchema schema = schemaGenerator.Generate(typeof(List<SkillVariant>));
            string help = schema.ToString();
            //string temp = JsonConvert.SerializeObject(new SkillVariant()
            //{
            //    Action = "1 Standard Action",
            //    Description = "Test",
            //    ID = 111,
            //    Restrictions = "Test",
            //    RulebookID = 1,
            //    SkillID = 9,
            //    Special = "a",
                
            //}, Formatting.Indented);
            Trace.WriteLine(help);
            //Trace.WriteLine(temp);
        }

        [TestMethod]
        public void GetRuleBookIDs()
        {
            //Trace.WriteLine(String.Join("\n", Model.GetInstance().SourceBooks.Select(x => x.ID.ToString("000") + " - " + x.Name)));
        }

        [TestMethod]
        public void ExportToMTGCardSet()
        {
            List<DnDCharacterSheetTool.Classes.DataModel.Spell> spells = DataLoader.Load<DnDCharacterSheetTool.Classes.DataModel.Spell>("Spells - Old Data.json");

            StreamWriter fileStream = File.CreateText("c:\\Users\\hysch\\Desktop\\set");
            fileStream.WriteLine(@"mse version: 0.3.8
game: magic
stylesheet: m15-altered
set info:
	symbol: 
	masterpiece symbol: 
styling:
	magic-m15-altered:
		text box mana symbols: magic-mana-small.mse-symbol-font
		overlay: ");

            foreach (var spell in spells.Take(100))
            {
                fileStream.WriteLine($@"card:
	has styling: false
	notes: 
	time created: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
	time modified: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
	card color: multicolor
	name: {spell.Name}
	casting cost: {spell.LevelPerClass.First().Value}
	image: 
	super type: <word-list-type>{String.Join("/", spell.Schools)}{String.Join("/", spell.SubSchools)}{String.Join("/", spell.Descriptor)}</word-list-type>
	sub type: {spell.LevelPerClass.First().Key}
	rule text:
		Casting Time: {spell.CastingTimeValue + " " + spell.CastingTimeIndicator.ToString()}
		Components: {String.Join(", ", spell.Components)}
		Range: {spell.Range}{(!String.IsNullOrEmpty(spell.Target) ? "\n\t\tTarget: " + spell.Target : "") + (!String.IsNullOrEmpty(spell.Area) ? "\n\t\tArea: " + spell.Area : "") + (!String.IsNullOrEmpty(spell.Effect) ? "\n\t\tEffect: " + spell.Effect : "")}
		Duration: {spell.Duration}
		Saving Throw: {(spell.SavingThrow ? spell.Saves : "none")}
        Spell Resistance: {(spell.SpellResistance ? "Yes" : "No")}
	flavor text: <i-flavor></i-flavor>
	card code text: 
	copyright: 
	image 2: 
	copyright 2: 
	copyright 3: 
	mainframe image: 
	mainframe image 2: ");
            }

            fileStream.WriteLine(@"version control:
	type: none
apprentice code: ");

            fileStream.Close();
        }
    }
}
