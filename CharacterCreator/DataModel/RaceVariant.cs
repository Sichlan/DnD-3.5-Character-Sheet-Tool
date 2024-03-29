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
    
    public partial class RaceVariant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceVariant()
        {
            this.RaceStatChanges = new HashSet<RaceStatChanx>();
            this.RacialMovementModes = new HashSet<RacialMovementMode>();
            this.RacialSenses = new HashSet<RacialSens>();
            this.Languages = new HashSet<Language>();
            this.Languages1 = new HashSet<Language>();
            this.SizeCategories = new HashSet<SizeCategory>();
        }
    
        public int ID { get; set; }
        public int RaceID { get; set; }
        public int RuleBookID { get; set; }
        public Nullable<int> Page { get; set; }
        public Nullable<int> SubraceOfID { get; set; }
        public int CreatureTypeID { get; set; }
        public Nullable<int> FavouredClass { get; set; }
        public int CountRacialHitDice { get; set; }
        public Nullable<int> SizeRacialHitDie { get; set; }
        public Nullable<int> LevelAdjustment { get; set; }
        public Nullable<int> Space { get; set; }
        public Nullable<int> Reach { get; set; }
        public Nullable<int> NaturalArmor { get; set; }
        public string Combat { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> BABType { get; set; }
        public Nullable<decimal> FortType { get; set; }
        public Nullable<decimal> RefType { get; set; }
        public Nullable<decimal> WillType { get; set; }
        public Nullable<int> BaseSkillPoints { get; set; }
    
        public virtual CreatureType CreatureType { get; set; }
        public virtual Race Race { get; set; }
        public virtual Race ParentRace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceStatChanx> RaceStatChanges { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RacialMovementMode> RacialMovementModes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RacialSens> RacialSenses { get; set; }
        public virtual RuleBook RuleBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SizeCategory> SizeCategories { get; set; }
    }
}
