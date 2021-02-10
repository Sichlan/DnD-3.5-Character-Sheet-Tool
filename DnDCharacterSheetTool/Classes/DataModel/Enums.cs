namespace DnDCharacterSheetTool.Classes.DataModel
{
    //https://stackoverflow.com/questions/28671828/binding-to-display-name-attribute-of-enum-in-xaml
    public enum SpellSchool
    {
        None,
        Abjuration,
        Alteration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation,
        Universal
    }

    public enum SubSchool
    {
        Calling,
        Creation,
        Healing,
        Summoning,
        Teleportation,
        Scrying,
        Charm,
        Compulsion,
        Figment,
        Glamer,
        Pattern,
        Phantasm,
        Shadow
    }

    public enum Descriptor
    {
        Acid,
        Air,
        Chaotic,
        Cold,
        Darkness,
        Death,
        Earth,
        Electricity,
        Evil,
        Fear,
        Fire,
        Force,
        Good,
        Language_dependent,
        Lawful,
        Light,
        Mind_affecting,
        Sonic,
        Water
    }

    public enum SpellType
    {
        None,
        Arcane,
        Divine
    }

    public enum CastingTimeIndicator
    {
        Immediate,
        Swift,
        Free,
        Standard,
        Round,
        Minute,
        Hour,
        Day
    }

    public enum Saves
    {
        None,
        Will,
        Reflex,
        Fortitude
    }

    public enum SaveEffect
    {
        negate,
        disbelief,
        partial,
        half
    }

    public enum Attack
    {
        None,
        Touch,
        Ranged
    }

    public enum Attributes
    {
        Strength = 1,
        Dexterity = 2,
        Constitution = 3,
        Intelligence = 4,
        Wisdom = 5,
        Charisma = 6
    }

    public enum LNCAlignment
    {
        Lawful,
        Neutral,
        Chaotic
    }

    public enum GNEAlignment
    {
        Good,
        Neutral,
        Evil
    }

    public enum CreatureType
    {
        Aberration = 0,
        Animal = 1,
        Celestial = 2,
        Construct = 3,
        Dragon = 4,
        Elemental = 5,
        Fey = 6,
        Fiend = 7,
        Giant = 8,
        Humanoid = 9,
        Magical_Beast = 10,
        Monstrous_Humanoid = 11,
        Ooze = 12,
        Outsider = 13,
        Plant = 14,
        Undead = 15,
        Vermin = 16
    }

    public enum CreatureSubTypes
    {
        Air = 0,
        Angel = 1,
        Aquatic = 2,
        Archon = 3,
        Augmented = 4,
        Chaotic = 5,
        Cold = 6,
        Demon = 7,
        Devil = 8,
        Dwarf = 9,
        Earth = 10,
        Elf = 11,
        Evil = 12,
        Extraplanar = 13,
        Fire = 14,
        Good = 15,
        Gnoll = 16,
        Gnome = 17,
        Goblinoid = 18,
        Halfling = 19,
        Human = 20,
        Incorporeal = 21,
        Lawful = 22,
        Native = 23,
        Orc = 24,
        Psionic = 25,
        Reptilian = 26,
        Shapechanger = 27,
        Swarm = 28,
        Water = 29
    }

    public enum SizeCategory
    {
        Fine = -4,
        Diminutive = -3,
        Tiny = -2,
        Small = -1,
        Medium = 0,
        Large = 1,
        Huge = 2,
        Gargantuan = 3,
        Colossal = 4,
        BiggerThanColossal = 5
    }

    public enum MovementMode
    {
        Ground,
        Fly,
        Swim,
        Burrow,
        Climb
    }

    public enum Sense
    {
        Low_Light,
        Darkvision,
        Tremorsense,
        Scent,
        Blindsense,
        Blindsight,
        Touchsight,
        Lifesight,
        Mindsight,
        Total_Vision,
        //Name from the warlockinvocation; Darkvision that also works in magical darkness
        Devilsight,
        Spirit_Sense,
        Clearsight
    }
}