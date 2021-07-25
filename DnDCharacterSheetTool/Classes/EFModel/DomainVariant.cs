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
    
    public partial class DomainVariant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DomainVariant()
        {
            this.Deities = new HashSet<Deity>();
            this.DomainSpells = new HashSet<DomainSpell>();
        }
    
        public int ID { get; set; }
        public int DomainID { get; set; }
        public int RuleBookID { get; set; }
        public string Name { get; set; }
    
        public virtual Domain Domain { get; set; }
        public virtual RuleBook RuleBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deity> Deities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomainSpell> DomainSpells { get; set; }
    }
}
