namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
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
}