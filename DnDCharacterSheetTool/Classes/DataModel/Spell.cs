using DnDCharacterSheetTool.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.DataModel
{
    [Serializable]
	public class Spell : INotifyPropertyChanged, ILoadable
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string sProperty = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(nameof(Name)); }
		}

		private string link;
		public string Link
		{
			get { return link; }
			set { link = value; OnPropertyChanged(nameof(Link)); }
		}

		private string source;
		public string Source
		{
			get { return source; }
			set { source = value; OnPropertyChanged(nameof(Source)); }
		}


		private List<SpellSchool> schools = new List<SpellSchool>();
		public List<SpellSchool> Schools
		{
			get { return schools; }
			set { schools = value; OnPropertyChanged(nameof(Schools)); }
		}

		private ObservableCollection<SubSchool> subSchools = new ObservableCollection<SubSchool>();
		public ObservableCollection<SubSchool> SubSchools
		{
			get { return subSchools; }
			set { subSchools = value; OnPropertyChanged(nameof(SubSchools)); }
		}

		private ObservableCollection<Descriptor> descriptor = new ObservableCollection<Descriptor>();
		public ObservableCollection<Descriptor> Descriptor
		{
			get { return descriptor; }
			set { descriptor = value; OnPropertyChanged(nameof(Descriptor)); }
		}

		private Dictionary<string, int> levelPerClass = new Dictionary<string, int>();
		public Dictionary<string, int> LevelPerClass
		{
			get { return levelPerClass; }
			set { levelPerClass = value; OnPropertyChanged(nameof(LevelPerClass)); }
		}

		private bool hasVerbal;
		public bool HasVerbal
		{
			get { return hasVerbal; }
			set { hasVerbal = value; OnPropertyChanged(nameof(HasVerbal)); }
		}

		private bool hasSomatic;
		public bool HasSomatic
		{
			get { return hasSomatic; }
			set { hasSomatic = value; OnPropertyChanged(nameof(HasSomatic)); }
		}

		private bool hasMaterial;
		public bool HasMaterial
		{
			get { return hasMaterial; }
			set { hasMaterial = value; OnPropertyChanged(nameof(HasMaterial)); }
		}

		private string materialComponents;
		public string MaterialComponents
		{
			get { return materialComponents; }
			set { materialComponents = value; OnPropertyChanged(nameof(MaterialComponents)); }
		}

		private bool hasArcaneFocus;
		public bool HasArcaneFocus
		{
			get { return hasArcaneFocus; }
			set { hasArcaneFocus = value; OnPropertyChanged(nameof(HasArcaneFocus)); }
		}

		private string arcaneFocus;
		public string ArcaneFocus
		{
			get { return arcaneFocus; }
			set { arcaneFocus = value; OnPropertyChanged(nameof(ArcaneFocus)); }
		}

		private bool divineFocus;
		public bool DivineFocus
		{
			get { return divineFocus; }
			set { divineFocus = value; OnPropertyChanged(nameof(DivineFocus)); }
		}

		private bool hasXpCost;
		public bool HasXpCost
		{
			get { return hasXpCost; }
			set { hasXpCost = value; OnPropertyChanged(nameof(HasXpCost)); }
		}


		private string xpCost;
		public string XPCost
		{
			get { return xpCost; }
			set { xpCost = value; OnPropertyChanged(nameof(XPCost)); }
		}

		private string otherComponents;
		public string OtherComponents
		{
			get { return otherComponents; }
			set { otherComponents = value; OnPropertyChanged(nameof(OtherComponents)); }
		}


		private int castingTimeValue;
		public int CastingTimeValue
		{
			get { return castingTimeValue; }
			set { castingTimeValue = value; OnPropertyChanged(nameof(CastingTimeValue)); }
		}

		private CastingTimeIndicator castingTimeIndicator;
		public CastingTimeIndicator CastingTimeIndicator
		{
			get { return castingTimeIndicator; }
			set { castingTimeIndicator = value; OnPropertyChanged(nameof(CastingTimeIndicator)); }
		}

		private string range;
		public string Range
		{
			get { return range; }
			set { range = value; OnPropertyChanged(nameof(Range)); }
		}

		private string target;
		public string Target
		{
			get { return target; }
			set { target = value; OnPropertyChanged(nameof(Target)); }
		}

		private string area;
		public string Area
		{
			get { return area; }
			set { area = value; OnPropertyChanged(nameof(Area)); }
		}

		private string effect;
		public string Effect
		{
			get { return effect; }
			set { effect = value; OnPropertyChanged(nameof(Effect)); }
		}

		private bool concentration;
		public bool Concentration
		{
			get { return concentration; }
			set { concentration = value; OnPropertyChanged(nameof(Concentration)); }
		}

		private string duration;
		public string Duration
		{
			get { return duration; }
			set { duration = value; OnPropertyChanged(nameof(Duration)); }
		}

		private bool savingThrow;
		public bool SavingThrow
		{
			get { return savingThrow; }
			set { savingThrow = value; OnPropertyChanged(nameof(SavingThrow)); }
		}

		private string saves;
		public string Saves
		{
			get { return saves; }
			set { saves = value; OnPropertyChanged(nameof(Saves)); }
		}

		private bool spellResistance;
		public bool SpellResistance
		{
			get { return spellResistance; }
			set { spellResistance = value; OnPropertyChanged(nameof(SpellResistance)); }
		}

		private bool harmless;
		public bool Harmless
		{
			get { return harmless; }
			set { harmless = value; OnPropertyChanged(nameof(Harmless)); }
		}

		private bool targetsObject;
		public bool TargetsObject
		{
			get { return targetsObject; }
			set { targetsObject = value; OnPropertyChanged(nameof(TargetsObject)); }
		}

		[JsonIgnore]
		public string Macro
		{
			get
			{
				string output = $"\n\n{Name}({Source}):\n";

				foreach (var Class in LevelPerClass)
				{
					output += $"\n\t{Class.Key} - {Class.Value}";
					output += !String.IsNullOrEmpty(Flavour) ? $"\n\t\t/me {Flavour}" : "";
					output += $"\n\t\t/w gm &{{template:DnD35StdRoll}} {{{{spellflag=true}}}} {{{{name=@{{character_name}}}}}} {{{{subtags=casts [{Name}]({Link}) }}}}";
					output += $" {{{{School:= {String.Join("/", Schools.Select(X => X.ToString()))} {(SubSchools.Count > 0 ? $"({String.Join("/", SubSchools)})" : "")} {(Descriptor.Count > 0 ? $"[{String.Join("][", Descriptor)}]" : "")}}}}}";
					output += $" {{{{Level:= **{Class.Key} {Class.Value}**{(LevelPerClass.Count > 1 ? ", " + String.Join(", ", LevelPerClass.Where(x => x.Key != Class.Key).Select(y => y.Key + " " + y.Value)) : "")}}}}}";
					output += $" {{{{Components:= {(String.Join(", ", Components.Where(X => !String.IsNullOrEmpty(X))))}}}}}";
					if(HasMaterial)
						output += $" {{{{Material Component:= {MaterialComponents}}}}}";
					if (HasArcaneFocus)
						output += $" {{{{Arcane Focus:= {ArcaneFocus}}}}}";
					if (HasXpCost)
						output += $" {{{{XP-Cost= {XPCost}}}}}";
					output += $" {{{{Range:= {(Range == "C" ? "Close([[25 + floor(@{casterlevel2}/ 2) * 5]] ft)" : Range == "M" ? "Medium ([[100+floor(@{casterlevel2})*10]] ft)" : Range == "L" ? "Long ([[400+floor(@{casterlevel2})*40]] ft)" : Range)}}}}}";
					output += $" {(!String.IsNullOrEmpty(Target) ? "{{Target:=" + Target + "}}" : "")}{(!String.IsNullOrEmpty(Area) ? "{{Area:=" + Area + "}}" : "")}{(!String.IsNullOrEmpty(Effect) ? "{{Effect:=" + Effect + "}}" : "")}";
					output += $" {(!String.IsNullOrEmpty(Duration) ? "{{Duration:=" + Duration + "}}" : "")} {{{{Savingthrow:={Saves} {(Harmless ? "(harmless)" : "")}}}}} {(SavingThrow ? $"{{{{Save DC:=[[@{{spelldc{Class.Value}}}+{String.Join("+", Schools.Select(x => "@{sf-" + x.ToString() + "}"))}]]}}}}" : "")}";
					output += $" {{{{Spellresistance:={(SpellResistance ? "Yes" : "No")} {(Harmless ? "(harmless)" : "")}}}}} {(SpellResistance && !Harmless ? $"{{{{CLC:= [[ 1d20+@{{casterlevel2}}+@{{spellpen}} ]] vs spell resistance.}}}}" : "")}";
					output += " {{compcheck=Concentration: [[ {1d20+ [[ @{concentration} ]] }>[[?{Damage Taken|0}+15+0]] ]] }} {{succeedcheck=Success! @{subjective} casts @{possessive} spell!}} {{failcheck=@{subjective} fails @{possessive} concentration :( }}";
					output += $" {{{{notes={Description.Substring(0, Description.Length - 1)}}}}}";
				}

				return output;
			}
		}

		public string GetDistinctMacro(string wantedClass)
		{
			if (LevelPerClass.FirstOrDefault(x => x.Key == wantedClass).Key == null)
				return "";
			else
			{
				KeyValuePair<string, int> Class = LevelPerClass.First(x => x.Key == wantedClass);
				string output = $"\n\n{Name}({Source}): - {Class.Key}({Class.Value})";
				output += !String.IsNullOrEmpty(Flavour) ? $"\n\t/me {Flavour}" : "";
				output += $"\n\t/w gm &{{template:DnD35StdRoll}} {{{{spellflag=true}}}} {{{{name=@{{character_name}}}}}} {{{{subtags=casts [{Name}]({Link}) }}}}";
				output += $" {{{{School:= {String.Join("/", Schools.Select(X => X.ToString()))} {(SubSchools.Count > 0 ? $"({String.Join("/", SubSchools)})" : "")} {(Descriptor.Count > 0 ? $"[{String.Join("][", Descriptor)}]" : "")}}}}}";
				output += $" {{{{Level:= **{Class.Key} {Class.Value}**{(LevelPerClass.Count > 1 ? ", " + String.Join(", ", LevelPerClass.Where(x => x.Key != Class.Key).Select(y => y.Key + " " + y.Value)) : "")}}}}}";
				output += $" {{{{Components:= {(String.Join(", ", Components.Where(X => !String.IsNullOrEmpty(X))))}}}}}";
				if (HasMaterial)
					output += $" {{{{Material Component:= {MaterialComponents}}}}}";
				if (HasArcaneFocus)
					output += $" {{{{Arcane Focus:= {ArcaneFocus}}}}}";
				if (HasXpCost)
					output += $" {{{{XP-Cost= {XPCost}}}}}";
				output += $" {{{{Range:= {(Range == "C" ? "Close([[25 + floor(@{casterlevel2}/ 2) * 5]] ft)" : Range == "M" ? "Medium ([[100+floor(@{casterlevel2})*10]] ft)" : Range == "L" ? "Long ([[400+floor(@{casterlevel2})*40]] ft)" : Range)}}}}}";
				output += $" {(!String.IsNullOrEmpty(Target) ? "{{Target:=" + Target + "}}" : "")}{(!String.IsNullOrEmpty(Area) ? "{{Area:=" + Area + "}}" : "")}{(!String.IsNullOrEmpty(Effect) ? "{{Effect:=" + Effect + "}}" : "")}";
				output += $" {(!String.IsNullOrEmpty(Duration) ? "{{Duration:=" + Duration + "}}" : "")} {{{{Savingthrow:={Saves} {(Harmless ? "(harmless)" : "")}}}}} {(SavingThrow ? $"{{{{Save DC:=[[@{{spelldc{Class.Value}}}+{String.Join("+", Schools.Select(x => "@{sf-" + x.ToString() + "}"))}]]}}}}" : "")}";
				output += $" {{{{Spellresistance:={(SpellResistance ? "Yes" : "No")} {(Harmless ? "(harmless)" : "")}}}}} {(SpellResistance && !Harmless ? $"{{{{CLC:= [[ 1d20+@{{casterlevel2}}+@{{spellpen}} ]] vs spell resistance.}}}}" : "")}";
				output += " {{compcheck=Concentration: [[ {1d20+ [[ @{concentration} ]] }>[[?{Damage Taken|0}+15+0]] ]] }} {{succeedcheck=Success! @{subjective} casts @{possessive} spell!}} {{failcheck=@{subjective} fails @{possessive} concentration :( }}";
				output += $" {{{{notes={Description.Substring(0, Description.Length - 1)}}}}}";

				return output;
			}
		}

		public string GetMacroWithoutShenannigans(string WantedClass)
		{
			if (LevelPerClass.FirstOrDefault(x => x.Key == WantedClass).Key == null)
				return "";
			else
			{
				KeyValuePair<string, int> Class = LevelPerClass.First(x => x.Key == WantedClass);
				string output = $"/w gm &{{template:DnD35StdRoll}} {{{{spellflag=true}}}} {{{{name=@{{character_name}}}}}} {{{{subtags=casts [{Name}]({Link}) }}}}";
				output += $" {{{{School:= {String.Join("/", Schools.Select(X => X.ToString()))} {(SubSchools.Count > 0 ? $"({String.Join("/", SubSchools)})" : "")} {(Descriptor.Count > 0 ? $"[{String.Join("][", Descriptor)}]" : "")}}}}}";
				output += $" {{{{Level:= **{Class.Key} {Class.Value}**{(LevelPerClass.Count > 1 ? ", " + String.Join(", ", LevelPerClass.Where(x => x.Key != Class.Key).Select(y => y.Key + " " + y.Value)) : "")}}}}}";
				output += $" {{{{Components:= {(String.Join(", ", Components.Where(X => !String.IsNullOrEmpty(X))))}}}}}";
				if (HasMaterial)
					output += $" {{{{Material Component:= {MaterialComponents}}}}}";
				if (HasArcaneFocus)
					output += $" {{{{Arcane Focus:= {ArcaneFocus}}}}}";
				if (HasXpCost)
					output += $" {{{{XP-Cost= {XPCost}}}}}";
				output += $" {{{{Range:= {(Range == "C" ? "Close([[25 + floor(@{casterlevel2}/ 2) * 5]] ft)" : Range == "M" ? "Medium ([[100+floor(@{casterlevel2})*10]] ft)" : Range == "L" ? "Long ([[400+floor(@{casterlevel2})*40]] ft)" : Range)}}}}}";
				output += $" {(!String.IsNullOrEmpty(Target) ? "{{Target:=" + Target + "}}" : "")}{(!String.IsNullOrEmpty(Area) ? "{{Area:=" + Area + "}}" : "")}{(!String.IsNullOrEmpty(Effect) ? "{{Effect:=" + Effect + "}}" : "")}";
				output += $" {(!String.IsNullOrEmpty(Duration) ? "{{Duration:=" + Duration + "}}" : "")} {{{{Savingthrow:={Saves} {(Harmless ? "(harmless)" : "")}}}}} {(SavingThrow ? $"{{{{Save DC:=[[@{{spelldc{Class.Value}}}+{String.Join("+", Schools.Select(x => "@{sf-" + x.ToString() + "}"))}]]}}}}" : "")}";
				output += $" {{{{Spellresistance:={(SpellResistance ? "Yes" : "No")} {(Harmless ? "(harmless)" : "")}}}}} {(SpellResistance && !Harmless ? $"{{{{CLC:= [[ 1d20+@{{casterlevel2}}+@{{spellpen}} ]] vs spell resistance.}}}}" : "")}";
				output += " {{compcheck=Concentration: [[ {1d20+ [[ @{concentration} ]] }>[[?{Damage Taken|0}+15+0]] ]] }} {{succeedcheck=Success! @{subjective} casts @{possessive} spell!}} {{failcheck=@{subjective} fails @{possessive} concentration :( }}";
				output += $" {{{{notes={Description.Substring(0, Description.Length - 1)}}}}}";

				return output;
			}
		}

		public string ShortDescription(string Class)
		{
			if (LevelPerClass.ContainsKey(Class))
				return $"{String.Join("/", Schools.Select(x => x.ToString()))}{(SubSchools.Count > 0 ? $" [{String.Join("][", SubSchools)}]" : "")}{(Descriptor.Count > 0 ? $" ({ String.Join(")(", Descriptor)})" : "")} {LevelPerClass[Class]}"
					+ $"\n{String.Join(", ", Components.Where(x => !String.IsNullOrEmpty(x)))}"
					+ (HasMaterial ? "\n" + MaterialComponents : "")
					+ (HasArcaneFocus ? "\n" + ArcaneFocus : "")
					+ (HasXpCost ? "\n" + XPCost : "")
					+ $"\n{(Range == "C" ? "Close([[25 + floor(@{casterlevel2}/ 2) * 5]] ft)" : Range == "M" ? "Medium ([[100+floor(@{casterlevel2})*10]] ft)" : Range == "L" ? "Long ([[400+floor(@{casterlevel2})*40]] ft)" : Range)}"
					+ $"{(!String.IsNullOrEmpty(Target) ? "\n" + Target : "")}{(!String.IsNullOrEmpty(Area) ? "\n" + Area : "")}{(!String.IsNullOrEmpty(Effect) ? "\n" + Effect : "")}"
					+ $"{(!String.IsNullOrEmpty(Duration) ? "\n" + Duration : "")}"
					+ $"\n{Description.Substring(0, Description.Length - 1)}";
			else
				return "";
		}

		[JsonIgnore]
		public List<string> Components
		{
			get
			{
				return new List<string>() { (HasVerbal ? "V" : ""), (HasSomatic ? "S" : ""), (HasMaterial ? "M" : ""), (HasArcaneFocus ? "AF" : ""), (DivineFocus ? "DF" : ""), (HasXpCost ? "XP" : ""), (String.IsNullOrEmpty(OtherComponents) ? "" : OtherComponents) };
			}
		}

		[JsonIgnore]
		public string AllClasses
		{
			get
			{
				return String.Join("\n", LevelPerClass.Select(x => x.Key + ": " + x.Value));
			}
		}

		private Attack attackType;
		public Attack AttackType
		{
			get { return attackType; }
			set { attackType = value; OnPropertyChanged(nameof(AttackType)); }
		}

		private Attributes? attackWith;
		public Attributes? AttackWith
		{
			get { return attackWith; }
			set { attackWith = value; OnPropertyChanged(nameof(AttackWith)); }
		}

		private int attackBonus;
		public int AttackBonus
		{
			get { return attackBonus; }
			set { attackBonus = value; OnPropertyChanged(nameof(AttackBonus)); }
		}

		private string damage;
		public string Damage
		{
			get { return damage; }
			set { damage = value; OnPropertyChanged(nameof(Damage)); }
		}

		private string description;
		public string Description
		{
			get { return description; }
			set { description = value; OnPropertyChanged(nameof(Description)); }
		}

		private string flavour;
		public string Flavour
		{
			get { return flavour; }
			set { flavour = value; OnPropertyChanged(nameof(Flavour)); }
		}

        public string SavePath => "Spells.json";
    }
}
