using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBEnemy : DBObject
    {
        private static int MaxItemDrops = 3;
        #region Declarations        
        private int maxHP;
        private int attack;
        private int defense;
        private int magicAttack;
        private int magicDefense;
        private int critRate;
        private int accuracy;
        private int evasion;
        private int morale;
        private int numberOfHits;

        private List<int> enemyTypeIds;

        //Rewards
        private int experience;
        private int gold;

        //Item drops
        private int[] itemIds = new int[MaxItemDrops];
        private int[] itemDropRates = new int[MaxItemDrops];
        private int[] itemTypes = new int[MaxItemDrops];

        private List<EnemyAction> actionList;

        private List<DBTrait> traits;

        private string note;
        
        #endregion

        #region Properties        
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int MagicAttack { get => magicAttack; set => magicAttack = value; }
        public int MagicDefense { get => magicDefense; set => magicDefense = value; }
        public int CritRate { get => critRate; set => critRate = value; }
        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Evasion { get => evasion; set => evasion = value; }
        public int Morale { get => morale; set => morale = value; }
        public int NumberOfHits { get => numberOfHits; set => numberOfHits = value; }

        public List<int> EnemyTypeIds { get => enemyTypeIds; set => enemyTypeIds = value; }

        public int Experience { get => experience; set => experience = value; }
        public int Gold { get => gold; set => gold = value; }

        public int[] ItemIds { get => itemIds; set => itemIds = value; }
        public int[] ItemDropRates { get => itemDropRates; set => itemDropRates = value; }
        public int[] ItemTypes { get => itemTypes; set => itemTypes = value; }

        public List<EnemyAction> ActionList { get => actionList; set => actionList = value; }

        public List<DBTrait> Traits { get => traits; set => traits = value; }

        public string Note { get => note; set => note = value; }
        #endregion

        #region Constructor(s)
        public DBEnemy()
        {
            Id = 1;
            Name = "";
            MaxHP = 1;
            Attack = 1;
            Defense = 0;
            MagicAttack = 1;
            MagicDefense = 1;
            CritRate = 1;
            Accuracy = 1;
            Evasion = 1;
            Morale = 1;
            NumberOfHits = 1;
            EnemyTypeIds = new List<int>();
            Experience = 0;
            Gold = 0;
           
            ItemIds = new int[MaxItemDrops];
            ItemDropRates = new int[MaxItemDrops];
            ItemTypes = new int[MaxItemDrops];            

            ActionList = new List<EnemyAction>();

            Traits = new List<DBTrait>();

            Note = "";
        }

        public DBEnemy(int id,
                       string name,
                       int maxHP,
                       int attack,
                       int defense,
                       int magicAttack,
                       int magicDefense,
                       int critRate,
                       int accuracy,
                       int evasion,
                       int morale,
                       int numberOfHits,
                       List<int> enemyTypeIds,
                       int experience,
                       int gold,
                       int[] itemIds,
                       int[] itemDropRates,
                       int[] itemTypes,
                       List<EnemyAction> actionList,
                       List<DBTrait> traits,
                       string note)
        {
            Id = id;
            Name = name;
            MaxHP = maxHP;
            Attack = attack;
            Defense = defense;
            MagicAttack = magicAttack;
            MagicDefense = magicDefense;
            CritRate = critRate;
            Accuracy = accuracy;
            Evasion = evasion;
            Morale = morale;
            NumberOfHits = numberOfHits;
            EnemyTypeIds = enemyTypeIds;
            Experience = experience;
            Gold = gold;
            ItemIds = itemIds;
            ItemDropRates = itemDropRates;
            ItemTypes = itemTypes;
            ActionList = actionList;
            Traits = traits;
            Note = note;
        }
        #endregion

        #region Methods

        #endregion

    }

   

}
