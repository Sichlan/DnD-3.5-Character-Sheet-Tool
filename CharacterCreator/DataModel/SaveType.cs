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
    
    public partial class SaveType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaveType()
        {
            this.AllowedSpellSaves = new HashSet<AllowedSpellSave>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AllowedSpellSave> AllowedSpellSaves { get; set; }
    }
}
