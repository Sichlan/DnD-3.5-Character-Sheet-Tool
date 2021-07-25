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
    
    public partial class SizeCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SizeCategory()
        {
            this.RaceVariants = new HashSet<RaceVariant>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int AttackAndACMod { get; set; }
        public int SpecialAttacksMod { get; set; }
        public int HideMod { get; set; }
        public decimal Space { get; set; }
        public int ReachTall { get; set; }
        public int ReachLong { get; set; }
        public decimal CarryingCapacitorModificatorBiped { get; set; }
        public decimal CarryingCapacitorModificatorQuadruped { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceVariant> RaceVariants { get; set; }
    }
}
