using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Feat : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }


        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
