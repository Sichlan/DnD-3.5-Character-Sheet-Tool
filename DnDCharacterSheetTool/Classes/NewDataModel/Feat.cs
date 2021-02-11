﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;
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

        [JsonProperty("Name")]
        public string Name { get; set; }

        
        
        [JsonIgnore]
        public ObservableCollection<FeatVariant> FeatVariants
        {
            get => new ObservableCollection<FeatVariant>(Model.GetInstance().FeatVariants.Where(x => x.FeatID == ID));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}