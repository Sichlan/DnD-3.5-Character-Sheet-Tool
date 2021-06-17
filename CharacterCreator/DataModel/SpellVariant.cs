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
    
    public partial class SpellVariant
    {
        public int ID { get; set; }
        public int SpellID { get; set; }
        public int RuleBookID { get; set; }
        public Nullable<int> Page { get; set; }
        public bool HasVerbal { get; set; }
        public bool HasSomatic { get; set; }
        public string Material { get; set; }
        public string ArcaneFocus { get; set; }
        public string DivineFocus { get; set; }
        public Nullable<int> XPCost { get; set; }
        public int CastingTimeValue { get; set; }
        public int CastingTimeIndicatorID { get; set; }
        public string Range { get; set; }
        public string Target { get; set; }
        public string Area { get; set; }
        public string Effect { get; set; }
        public bool Concentration { get; set; }
        public string Duration { get; set; }
        public bool Harmless { get; set; }
        public bool TargetsObject { get; set; }
    
        public virtual ActionTimeIndicator ActionTimeIndicator { get; set; }
        public virtual RuleBook RuleBook { get; set; }
        public virtual Spell Spell { get; set; }
    }
}