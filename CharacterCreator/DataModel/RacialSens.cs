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
    
    public partial class RacialSens
    {
        public int RaceID { get; set; }
        public int SenseID { get; set; }
        public int Distance { get; set; }
    
        public virtual RaceVariant RaceVariant { get; set; }
        public virtual VisualSense VisualSense { get; set; }
    }
}