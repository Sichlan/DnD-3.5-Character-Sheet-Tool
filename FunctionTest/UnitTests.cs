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
            JSchema schema = schemaGenerator.Generate(typeof(List<RaceVariant>));
            string help = schema.ToString();
            Trace.WriteLine(help);
        }
    }
}
