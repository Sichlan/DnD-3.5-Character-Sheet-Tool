//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CharacterCreator.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeatRequiresStatValue
    {
        public int ID { get; set; }
        public int AbilityStatID { get; set; }
        public int FeatID { get; set; }
        public int MinValue { get; set; }
    
        public virtual AbilityStat AbilityStat { get; set; }
        public virtual Feat Feat { get; set; }
    }
}
