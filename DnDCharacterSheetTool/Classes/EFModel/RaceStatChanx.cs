//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnDCharacterSheetTool.Classes.EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceStatChanx
    {
        public int ID { get; set; }
        public int RaceID { get; set; }
        public int AbilityStatID { get; set; }
        public int Bonus { get; set; }
    
        public virtual AbilityStat AbilityStat { get; set; }
        public virtual RaceVariant RaceVariant { get; set; }
    }
}
