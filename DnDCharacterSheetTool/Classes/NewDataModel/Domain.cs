using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Domain : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }



        [JsonIgnore]
        public ObservableCollection<DomainVariant> DomainVariants
        {
            get => new ObservableCollection<DomainVariant>(Model.GetInstance().DomainVariants.Where(x => x.DomainID == ID));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}