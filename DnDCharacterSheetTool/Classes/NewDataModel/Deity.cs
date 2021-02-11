using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Deity : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Alignment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Alignment Alignment { get; set; }

        [JsonProperty("DomainIds")]
        public ObservableCollection<int> DomainIDs { get; set; }

        //TODO: Add favoured weapon of deity when items are implemented

        [JsonIgnore]
        public ObservableCollection<Domain> Domains
        {
            get => new ObservableCollection<Domain>(Model.GetInstance().Domains.Where(x => DomainIDs.Contains(x.ID)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
