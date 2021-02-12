using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Race : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }



        [JsonIgnore]
        public ObservableCollection<RaceVariant> RaceVariants
        {
            get => new ObservableCollection<RaceVariant>(Model.GetInstance().RaceVariants.Where(x => x.RaceID == ID));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
