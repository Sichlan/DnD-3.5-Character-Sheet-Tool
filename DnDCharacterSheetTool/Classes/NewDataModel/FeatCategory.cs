﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeatCategory
    {
        Aberrant,
        AbyssalHeritor,
        Ambush,
        Ancestor,
        Background,
        Bardic,
        Bloodgift,
        Bloodline,
        Breath,
        Ceremony,
        CombatForm,
        Corrupter,
        Creature,
        Deformity,
        DevilTouched,
        Divine,
        Domain,
        Dominator,
        Draconic,
        Dreamtouched,
        Epic,
        Exalted,
        Faith,
        FighterBonusFeat,
        General,
        Ghost,
        Haunt,
        Heritage,
        Host,
        Incarnum,
        Initiate,
        Interaction,
        ItemCreation,
        Leader,
        Legacy,
        Luck,
        Manipulation,
        Mental,
        Metabreath,
        Metamagic,
        Metapsionic,
        Metashadow,
        Monster,
        Monstrous,
        Movement,
        NodeMagic,
        Poltergeist,
        Psionic,
        Racial,
        Regional,
        Reserve,
        Shaper,
        Shifter,
        Special,
        Spelltouched,
        Style,
        Tactical,
        Tainted,
        Trait,
        Traveler,
        Vile,
        Warforged,
        Wild
    }
}