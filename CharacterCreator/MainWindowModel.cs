using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using CharacterCreator.DataModel;

namespace CharacterCreator
{
    class MainWindowModel : IDisposable
    {
        public Entities Model { get; set; }

        public MainWindowModel()
        {
            Model = new Entities();
        }

        public void Dispose()
        {
            Model.Dispose();
        }
    }
}
