using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public partial class Edition : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("System")]
        public string System { get; set; }

        [JsonProperty("Core")]
        public bool IsCore { get; set; }

        [JsonIgnore]
        public ObservableCollection<SourceBook> SourceBooks 
        { 
            get
            {
                return new ObservableCollection<SourceBook>(Model.GetInstance().SourceBooks.Where(x => x.EditionID == this.ID).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
