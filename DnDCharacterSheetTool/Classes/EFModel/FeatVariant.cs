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
    
    public partial class FeatVariant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeatVariant()
        {
            this.Feats = new HashSet<Feat>();
            this.FeatCategories = new HashSet<FeatCategory>();
            this.Alignments = new HashSet<Alignment>();
        }
    
        public int ID { get; set; }
        public int FeatID { get; set; }
        public int RuleBookID { get; set; }
        public Nullable<int> PageNo { get; set; }
        public string Description { get; set; }
        public Nullable<int> RequiredCharacterLevel { get; set; }
        public Nullable<int> RequiredCharacterBAB { get; set; }
        public Nullable<int> RequiredCasterLevel { get; set; }
        public Nullable<int> RequiredArcaneCasterLevel { get; set; }
        public Nullable<int> RequiredDivineCasterLevel { get; set; }
        public Nullable<int> RequiredPatreonDeityID { get; set; }
    
        public virtual Deity Deity { get; set; }
        public virtual Feat Feat { get; set; }
        public virtual RuleBook RuleBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feat> Feats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeatCategory> FeatCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alignment> Alignments { get; set; }
    }
}
