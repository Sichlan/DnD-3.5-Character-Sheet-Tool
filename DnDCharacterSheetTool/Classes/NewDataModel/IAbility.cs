using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public interface IAbility
    {
        [JsonProperty("UsesPerDay")]
        Nullable<int> UsesPerDay { get; set; }
    }

    public interface ISpellLikeReplicable
    {

    }

    public class SpellLikeAbility : IAbility, IFeatBenefit, INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Replicates")]
        public ISpellLikeReplicable Replicates { get; set; }

        [JsonProperty("UsesPerDay")]
        public int? UsesPerDay { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Extra")]
        public object Extra { get => null; set => value = null; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
