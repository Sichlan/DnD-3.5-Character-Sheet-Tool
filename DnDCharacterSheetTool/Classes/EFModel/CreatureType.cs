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
    
    public partial class CreatureType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CreatureType()
        {
            this.RaceVariants = new HashSet<RaceVariant>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int HitDieSize { get; set; }
        public decimal BABType { get; set; }
        public decimal FortType { get; set; }
        public decimal RefType { get; set; }
        public decimal WillType { get; set; }
        public int BaseSkillPoints { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceVariant> RaceVariants { get; set; }
    }
}