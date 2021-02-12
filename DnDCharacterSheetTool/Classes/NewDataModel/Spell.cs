using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Spell : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public int Name { get; set; }



        [JsonIgnore]
        public ObservableCollection<SpellVariant> SpellVariants
        {
            get => new ObservableCollection<SpellVariant>(Model.GetInstance().SpellVariants.Where(x => x.SpellID == ID));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
