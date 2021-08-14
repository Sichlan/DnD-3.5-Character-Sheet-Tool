using CharacterCreator.MVVM.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Media;

namespace CharacterCreatorTests
{
    [TestClass]
    public class RecentlyOpenedCharaterTest
    {
        [TestMethod]
        public void SaveAndLoadTestFile()
        {
            //Setup basic model with three recently viewed files:
            RecentlyUsedCharacterModel testModel = new RecentlyUsedCharacterModel();
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CharacterCreator.Properties.Settings.Default.SaveFolder;

            testModel.RecentlyUsedCharacter.Add(new RecentlyUsedCharacterEntry()
            {
                Name = "Test1",
                FolderPath = folderPath,
                FileName = "TestChar1.json",
                PreviewInfo = "TestRace Wiz 5 / Sor 3 / UltMag 5",
                LastUpdate = DateTime.Now,
                LeftColor = Brushes.DodgerBlue.Color
            });
            Thread.Sleep(1);
            testModel.RecentlyUsedCharacter.Add(new RecentlyUsedCharacterEntry()
            {
                Name = "Test2",
                FolderPath = folderPath,
                FileName = "BarbLoL.json",
                PreviewInfo = "TestRage Fig 5 / Bar 3 / FreBer 5",
                LastUpdate = DateTime.Now,
                LeftColor = Brushes.Crimson.Color
            });
            Thread.Sleep(1);
            testModel.RecentlyUsedCharacter.Add(new RecentlyUsedCharacterEntry()
            {
                Name = "Test3",
                FolderPath = folderPath,
                FileName = "Fighter.json",
                PreviewInfo = "Human Fig 20",
                LastUpdate = DateTime.Now,
                LeftColor = Brushes.Beige.Color
            });


            //Save the test model
            testModel.SaveRecentlyUsedCharacterModel();

            //load test model into another variable
            var newModel = RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel();
            Trace.WriteLine(newModel.ToString());

            //find elements from test model not included in new model
            string excepts = JsonConvert.SerializeObject(testModel.RecentlyUsedCharacter.Except(testModel.RecentlyUsedCharacter), Formatting.Indented);
            Trace.WriteLine(excepts);

            //if every element of test model had been included in the new model the excepts should look like "[]" as JSON, thus valöidating this test
            Trace.Assert(excepts == "[]");
        }
    }
}
