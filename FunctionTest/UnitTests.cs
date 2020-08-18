using System;
using System.Collections.Generic;
using DnD_3._5_Character_Sheet_Tool.Classes.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void LoadAndSaveSpells()
        {
            List<Spell> spells = DataLoader.Load<Spell>("Spells.json");
            DataLoader.Save<Spell>(spells, "Spells.json");
        }

        [TestMethod]
        public void ReWriteRaceTemp()
        {
            var help = DataLoader.Load<object>("RaceTEMP.json");
        }
    }
}
