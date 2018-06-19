using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBArmor
    {
        private static int MaxMagicSlots = 8;
        #region Declarations
        private int id;
        private string name;
        private int iconId;
        private string description;
        private int armorType;
        private int equipmentType;
        private int price;

        //Parameter changes
        private int attack;
        private int defense;
        private int magicAttack;
        private int magicDefense;
        private int hit;
        private int agility;
        private int luck;
        private int maxHP;
        //used if using MP
        private int maxMP;
        //used if using spell slots
        private int[] magicSlots = new int[MaxMagicSlots];

        private List<DBTrait> traits;

        private string note;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IconId { get => iconId; set => iconId = value; }
        public string Description { get => description; set => description = value; }
        public int ArmorType { get => armorType; set => armorType = value; }
        public int EquipmentType { get => equipmentType; set => equipmentType = value; }
        public int Price { get => price; set => price = value; }

        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int MagicAttack { get => magicAttack; set => magicAttack = value; }
        public int MagicDefense { get => magicDefense; set => magicDefense = value; }
        public int Hit { get => hit; set => hit = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Luck { get => luck; set => luck = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }

        public int MaxMP { get => maxMP; set => maxMP = value; }

        public int[] MagicSlots { get => magicSlots; set => magicSlots = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }

        public string Note { get => note; set => note = value; }
       
        #endregion

        #region Constructor(s)
        public DBArmor()
        {
            Id = 1;
            Name = "";
            IconId = 0;
            Description = "";
            ArmorType = 0;
            EquipmentType = 0;
            Price = 0;

            Attack = 0;
            Defense = 0;
            MagicAttack = 0;
            MagicDefense = 0;
            Hit = 0;
            Agility = 0;
            Luck = 0;
            MaxHP = 0;

            MaxMP = 0;

            for (int i = 0; i < MaxMagicSlots; i++)
            {
                MagicSlots[i] = 0;
            }

            Traits = new List<DBTrait>();

            Note = "";
        }

        public DBArmor(int id, 
                       string name, 
                       int iconId, 
                       string description, 
                       int armorType, 
                       int equipmentType, 
                       int price, 
                       int attack, 
                       int defense, 
                       int magicAttack, 
                       int magicDefense, 
                       int hit, 
                       int agility, 
                       int luck, 
                       int maxHP, 
                       int maxMP, 
                       int[] magicSlots,
                       List<DBTrait> traits, 
                       string note)
        {
            Id = id;
            Name = name;
            IconId = iconId;
            Description = description;
            ArmorType = armorType;
            EquipmentType = equipmentType;
            Price = price;
            Attack = attack;
            Defense = defense;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
            Hit = hit;
            Agility = agility;
            Luck = luck;
            MaxHP = maxHP;
            MaxMP = maxMP;
            MagicSlots = magicSlots;
            Traits = traits;
            Note = note;
        }


        #endregion
    }
}
