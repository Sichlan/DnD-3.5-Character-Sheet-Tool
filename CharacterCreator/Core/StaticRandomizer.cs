using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core
{
    public static class StaticRandomizer
    {
        private static Random Random;

        public static Random GetStaticRandom()
        {
            if (Random == null)
                Random = new Random();

            return Random;
        }
    }
}
