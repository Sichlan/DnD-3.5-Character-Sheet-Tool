using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CharacterCreator.MVVM.Model;

namespace CharacterCreatorTests
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void TestSaveCharacter()
        {
            Character.SetActiveCharacter(true);

            var character = Character.GetActiveCharacter();

            character.SaveCharacter();
        }
    }
}
