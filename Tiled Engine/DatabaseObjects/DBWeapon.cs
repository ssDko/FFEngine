using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBWeapon : DBObject
    {
        private static int MaxSpellSlots = 8;
        #region Declarations        
        private int iconId;
        private string description;
        private int weaponType;
        private int price;
        private int animationId;

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
        private int[] spellSlots = new int[MaxSpellSlots];

        private List<DBTrait> traits;

        private string note;
        #endregion

        #region Properties       
        public int IconId { get => iconId; set => iconId = value; }
        public string Description { get => description; set => description = value; }
        public int WeaponType { get => weaponType; set => weaponType = value; }
        public int Price { get => price; set => price = value; }
        public int AnimationId { get => animationId; set => animationId = value; }

        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int MagicAttack { get => magicAttack; set => magicAttack = value; }
        public int MagicDefense { get => magicDefense; set => magicDefense = value; }
        public int Hit { get => hit; set => hit = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Luck { get => luck; set => luck = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int MaxMP { get => maxMP; set => maxMP = value; }
        public int[] SpellSlots { get => spellSlots; set => spellSlots = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }

        public string Note { get => note; set => note = value; }
        
        #endregion

        #region Constructor(s)
        public DBWeapon()
        {
            Id = 1;
            Name = "";
            IconId = 0;
            Description = "";
            WeaponType = 0;
            price = 0;
            AnimationId = 0;

            Attack = 0;
            defense = 0;
            MagicAttack = 0;
            MagicDefense = 0;
            Hit = 0;
            Agility = 0;
            Luck = 0;
            MaxHP = 0;
            MaxMP = 0;
            SpellSlots = new int[MaxSpellSlots];

            Traits = new List<DBTrait>();

            Note = "";
        }

        public DBWeapon(int id, 
                        string name, 
                        int iconId, 
                        string description, 
                        int weaponType, 
                        int price, 
                        int animationId, 
                        int attack, 
                        int defense, 
                        int magicAttack, 
                        int magicDefense, 
                        int hit, 
                        int agility, 
                        int luck, 
                        int maxHP, 
                        int maxMP, 
                        int[] spellSlots,
                        List<DBTrait> traits, 
                        string note)
        {
            Id = id;
            Name = name;
            IconId = iconId;
            Description = description;
            WeaponType = weaponType;
            Price = price;
            AnimationId = animationId;
            Attack = attack;
            Defense = defense;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
            Hit = hit;
            Agility = agility;
            Luck = luck;
            MaxHP = maxHP;
            MaxMP = maxMP;
            SpellSlots = spellSlots;
            Traits = traits;
            Note = note;
        }


        #endregion

        #region Methods

        #endregion
    }
}
