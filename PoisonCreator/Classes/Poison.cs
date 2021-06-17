using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace PoisonCreator.Classes
{
    public class Poison
    {
        public Poison()
        {
            PrimaryDamage = new ObservableCollection<PotencyInstance>();
            SecondaryDamage = new ObservableCollection<PotencyInstance>();
        }

        public int CraftDC
        {
            get
            {
                return CalculateCraftDC();
            }
        }

        public bool IsAlreadyKnown { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int Toxicity { get; set; }

        public ObservableCollection<PotencyInstance> PrimaryDamage { get; set; }
        public ObservableCollection<PotencyInstance> SecondaryDamage { get; set; }
        
        private int CalculateCraftDC()
        {
            int dc = 10;

            if (!IsAlreadyKnown)
                dc += 5;

            switch (DeliveryMethod)
            {
                case DeliveryMethod.Injury:
                    dc += 0;
                    break;
                case DeliveryMethod.Ingestion:
                    dc -= 5;
                    break;
                case DeliveryMethod.Inhalation:
                case DeliveryMethod.Contact:
                    dc += 2;
                    break;
            }

            dc += Toxicity;
            dc += PrimaryDamage.Sum(x => x.DC);
            dc += SecondaryDamage.Sum(x => x.DC);
            return dc;
        }
    }

    public class PotencyInstance
    {
        public int DC
        {
            get
            {
                int sd = 0;

                switch (DamageType)
                {
                    case DamageType.BaseAttackBonus:
                    case DamageType.BaseSavingThrow:
                        sd = 2;
                        break;
                    case DamageType.NaturalArmorBonus:
                    case DamageType.PermanentAbility:
                    case DamageType.DamageReduction:
                        sd = 1;
                        break;
                    case DamageType.HitPoints:
                        sd = -8;
                        break;
                    case DamageType.SpellResistance:
                        sd = 2;
                        break;
                    case DamageType.Subdual:
                        sd = -12;
                        break;
                    case DamageType.TemporaryAbilityDamage:
                        sd = 0;
                        break;
                }

                return Math.Max(1, (CountDice * (int)Math.Ceiling((double)(DiceSize / 2)) + sd));
            }
        }
        public int CountDice { get; set; }

        public int DiceSize { get; set; }

        public DamageType DamageType { get; set; }

        public string Special { get; set; }
    }

    public enum DamageType
    {
        BaseAttackBonus,
        BaseSavingThrow,
        DamageReduction,
        HitPoints,
        NaturalArmorBonus,
        PermanentAbility,
        SpellResistance,
        Subdual,
        TemporaryAbilityDamage
    }

    public enum DeliveryMethod
    {
        Injury,
        Ingestion,
        Inhalation,
        Contact
    }
}
